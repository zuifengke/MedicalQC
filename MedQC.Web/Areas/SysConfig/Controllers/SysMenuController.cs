using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedQC.Web.Utility;
using MedQC.Web.Models;
using MedQC.Web.Filters;
using MedQC.Web.IBatisAccess;

namespace MedQC.Web.Areas.SysConfig.Controllers
{
    [MyException]
    public class SysMenuController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetGridList()
        {
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";

            var result = IBatisAccess.SysMenuDao.Instance.GetSysMenus(null).ToList();

            //List<Menus> lstMenus = new List<Menus>();
            //short shRet = SystemContext.Instance.MenuServices.GetMenuPageList(size, page, "", ref lstMenus);
            JsonHelper json = new JsonHelper();
            string strJson = string.Empty;
            foreach (SysMenu item in result)
            {
                json.AddItem("id", item.ID.ToString());
                json.AddItem("MenuName", item.MenuName);
                json.AddItem("Url", item.Url);
                if (item.ParentID != 0)
                    json.AddItem("_parentId", item.ParentID.ToString());
                json.AddItem("ParentName", item.ParentName);
                json.AddItem("Icon", item.Icon);
                json.AddItem("MenuType", item.MenuType);
                json.AddItem("Description", item.Description);
                json.ItemOk();
            }
            int totalCount = 0;
            //short shRet = SystemContext.Instance.MenuServices.GetMenuTotalCount("", ref totalCount);
            json.totlalCount = result.Count();
            if (json.totlalCount > 0)
            {
                strJson = json.ToEasyuiGridJsonString();
            }
            else
            {
                strJson = @"[]";
            }
            // json = "{ \"rows\":[ { \"ID\":\"48\",\"NewsTitle\":\"mr\",\"NewsContent\":\"mrsoft\",\"CreateTime\":\"2013-12-23\",\"CreateUser\":\"ceshi\",\"ModifyTime\":\"2013-12-23\",\"ModifyUser\":\"ceshi\"} ],\"total\":3}";
            //strJson = "{\"total\":2,\"rows\":[{\"id\":\"2\",\"MenuName\":\"ff\",\"Url\":\"ff\",\"ParentName\":\"\",\"Icon\":\"ff\",\"MenuType\":\"\"},{\"id\":\"1\",\"MenuName\":\"日\",\"Url\":\"1\",\"_parentId\":\"2\",\"ParentName\":\"\",\"Icon\":\"2\",\"MenuType\":\"\"}]}";
            return Content(strJson);

        }

        public ActionResult GetComboTree()
        {
            var lstMenus = SysMenuDao.Instance.GetSysMenus(null).ToList();
            //List < Menus > lstMenus = new List<Menus>();
            //     short shRet = SystemContext.Instance.MenuServices.GetMenuList("", ref lstMenus);
            DataTable dtMenus = GlobalMethods.Table.GetDataTable(lstMenus);
            DataRow dataRow = dtMenus.Rows.Add();
            dataRow["ID"] = "0";
            dataRow["ParentID"] = "-1";
            dataRow["MenuName"] = "父节点";
            string strJson = JsonHelper.GetTreeJsonByTable(dtMenus, "ID", "MenuName", "ParentID", "-1", "");
            //string strJson = "[{\"id\":\"1\",\"text\":\"hello1\",\"checked\":\"true\",\"state\":\"open\",\"children\":[{\"id\":\"2\",\"text\":\"hello2\",\"state\":\"open\"}]},{\"id\":\"1\",\"text\":\"hello1\",\"state\":\"open\",\"children\":[{\"id\":\"2\",\"text\":\"hello2\",\"state\":\"open\"}]}]";
            return Content(strJson);
        }
        public ActionResult QueryOneData()
        {
            string strJson = string.Empty;

            int id = Request.Form["id"] != "" ? int.Parse(Request.Form["id"]) : 0;
            var result = SysMenuDao.Instance.QueryOne(id);
            if (result.ParentName == null)
                result.ParentName = string.Empty;
            JsonHelper json = new JsonHelper();
            if (result != null)
            {

                json.AddItem("ID", result.ID.ToString());
                json.AddItem("MenuName", result.MenuName);
                json.AddItem("Url", result.Url);
                json.AddItem("ParentID", result.ParentID.ToString());
                json.AddItem("ParentName", result.ParentName);
                json.AddItem("Icon", result.Icon);
                json.AddItem("Description", result.Description);
                json.AddItem("MenuType", result.MenuType);
                json.ItemOk();
            }
            strJson = json.ToEasyuiOneModelJsonString();

            // strJson = "[{\"ID\":\"81\",\"EmpNo\":\"jxdhlgljp\",\"Name\":\"hello\",\"Pwd\":\"111111\",\"Tel\":\"18720081979\"}]";
            return Content(strJson);
        }
        public ActionResult Update()
        {
            string writeMsg = "操作失败！";

            int id = Request.Form["id"] != "" ? Convert.ToInt32(Request.Form["id"]) : 0;
            SysMenu model = GetData(id);
            if (model != null)
            {
                if (id == 0)
                {
                    bool result = SysMenuDao.Instance.Insert(model);

                    if (result)
                    {
                        writeMsg = "增加成功!";
                    }
                    else
                    {
                        writeMsg = "增加失败!";
                    }
                }
                else
                {
                    //清楚context中result对象
                    bool result = SysMenuDao.Instance.Update(model);
                    if (result)
                    {
                        writeMsg = "修改成功!";
                    }
                    else
                    {
                        writeMsg = "修改失败!";
                    }
                }
            }

            return Content(writeMsg);
        }
        public ActionResult DelData()
        {
            string writeMsg = "删除失败！";

            string selectID = Request.Form["cbx_select"] != "" ? Request.Form["cbx_select"] : "";

            if (selectID != string.Empty && selectID != "0")
            {
                int id = int.Parse(selectID);
                bool result = SysMenuDao.Instance.Delete(id);
                if (result)
                {
                    writeMsg = string.Format("删除成功");
                }
                else
                {
                    writeMsg = "删除失败！";
                }
            }

            return Content(writeMsg);
        }
        /// <summary>
        /// 取得数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private SysMenu GetData(int id)
        {

            SysMenu model = new SysMenu();
            model.ParentID = 0;
            if (id > 0)
            {
                //model = EnterRepository.GetRepositoryEnter().MenuRepository.LoadEntities(m => m.ID == id).FirstOrDefault();
                model = SysMenuDao.Instance.QueryOne(id);
            }
            //model.Name = Request.Form["ipt_Name"] != "" ? Request.Form["ipt_Name"] : "";
            //model.Url = Request.Form["ipt_Url"] != "" ? Request.Form["ipt_Url"] : "";
            model.MenuName = Request.Form["MenuName"] != "" ? Request.Form["MenuName"] : "";
            model.Url = Request.Form["Url"] != "" ? Request.Form["Url"] : "";
            model.ParentID = Request.Form["ParentID"] != "" ? int.Parse(Request.Form["ParentID"]) : 0;
            model.Icon = Request.Form["Icon"] != "" ? Request.Form["Icon"] : "";
            model.Description = Request.Form["Description"] != "" ? Request.Form["Description"] : "";
            model.MenuType = Request.Form["MenuType"] != "" ? Request.Form["MenuType"] : "";
            return model;

        }

        public ActionResult GetSysUserList()
        {
            string strJson = string.Empty;
            JsonHelper json = new JsonHelper();
            try
            {
                // var result = EnterRepository.GetRepositoryEnter().EmployeeRepository.LoadEntities().OrderBy(m => m.EmpNo).ToList();
                var result = SysUserDao.Instance.GetSysUsers(null);
                foreach (SysUser item in result)
                {
                    json.AddItem("ID", item.ID.ToString());
                    json.AddItem("LoginName", item.LoginName);
                    json.AddItem("Name", item.Name);
                    json.ItemOk();
                }

                json.totlalCount = result.Count;
                strJson = json.ToEasyuiGridJsonString();
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
            }

            return Content(strJson);
        }
        public ActionResult SaveByUserID()
        {
            try
            {
                string MenuID = Request.Form["MenuID"] != "" ? Request.Form["MenuID"].ToString() : "";
                string UserID = Request.Form["UserID"] != "" ? Request.Form["UserID"].ToString() : "";
                string[] arrMenuID = MenuID.Split(',');
                string writeMsg = "保存成功！";
                if (UserID == "")
                    writeMsg = "保存失败！";
                else
                {
                    //先删除
                    bool result = true;
                    result = SysMenuDao.Instance.DeleteUserMenu(int.Parse(UserID));
                    foreach (string item in arrMenuID)
                    {
                        if (string.IsNullOrEmpty(item))
                            continue;
                        int menuid = int.Parse(item);
                        int nuserid = int.Parse(UserID);
                        result = SysMenuDao.Instance.InsertUserMenu(nuserid, menuid);
                    }
                    if (!result)
                        writeMsg = "保存失败";
                }
                return Content(writeMsg);
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
                return Content("保存失败");
            }
        }

        public ActionResult GetMenuTree()
        {
            try
            {
                var lstMenus = SysMenuDao.Instance.GetSysMenus(null).ToList();
                DataTable dtMenu = GlobalMethods.Table.GetDataTable(lstMenus);
                //得到ID号
                string szCheckItems = string.Empty;
                if (Request.QueryString["UserID"] != null && Request.QueryString["UserID"] != "" && Request.QueryString["UserID"] != "0")
                {
                    int UserID = int.Parse(Request.QueryString["UserID"]);

                    var lstUserMenu = SysMenuDao.Instance.GetMenusByUserID(UserID);
                    foreach (SysMenu item in lstUserMenu)
                    {
                        szCheckItems += "," + item.ID;
                    }
                }
                string strJson = JsonHelper.GetTreeJsonByTable(dtMenu, "ID", "MenuName", "ParentID", "0", szCheckItems);
                return Content(strJson);
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
                return Content(string.Empty);
            }
            //string strJson = "[{\"id\":\"1\",\"text\":\"hello1\",\"checked\":\"true\",\"state\":\"open\",\"children\":[{\"id\":\"2\",\"text\":\"hello2\",\"state\":\"open\"}]},{\"id\":\"1\",\"text\":\"hello1\",\"state\":\"open\",\"children\":[{\"id\":\"2\",\"text\":\"hello2\",\"state\":\"open\"}]}]";

        }

        public ActionResult GetSysRoleList()
        {
            string strJson = string.Empty;
            JsonHelper json = new JsonHelper();
            try
            {
                // var result = EnterRepository.GetRepositoryEnter().EmployeeRepository.LoadEntities().OrderBy(m => m.EmpNo).ToList();
                var result = SysRoleDao.Instance.GetSysRoles(null);
                foreach (SysRole item in result)
                {
                    json.AddItem("ID", item.ID.ToString());
                    json.AddItem("Description", item.Description);
                    json.AddItem("Name", item.Name);
                    json.ItemOk();
                }

                json.totlalCount = result.Count;
                strJson = json.ToEasyuiGridJsonString();
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
            }

            return Content(strJson);
        }
        public ActionResult GetMenuTreeByRoleID()
        {
            var lstMenus = SysMenuDao.Instance.GetSysMenus(null).ToList();
            DataTable dtMenu = GlobalMethods.Table.GetDataTable(lstMenus);
            //得到ID号
            string szCheckItems = string.Empty;
            if (Request.QueryString["RoleID"] != null && Request.QueryString["RoleID"] != "" && Request.QueryString["RoleID"] != "0")
            {
                int RoleID = int.Parse(Request.QueryString["RoleID"]);
                var lstUserMenu = SysMenuDao.Instance.GetMenusByRoleID(RoleID);
                foreach (SysMenu item in lstUserMenu)
                {
                    szCheckItems += "," + item.ID;
                }
            }
            //string strJson = "[{\"id\":\"1\",\"text\":\"hello1\",\"checked\":\"true\",\"state\":\"open\",\"children\":[{\"id\":\"2\",\"text\":\"hello2\",\"state\":\"open\"}]},{\"id\":\"1\",\"text\":\"hello1\",\"state\":\"open\",\"children\":[{\"id\":\"2\",\"text\":\"hello2\",\"state\":\"open\"}]}]";
            string strJson = JsonHelper.GetTreeJsonByTable(dtMenu, "ID", "MenuName", "ParentID", "0", szCheckItems);
            return Content(strJson);
        }

        public ActionResult SaveByRoleID()
        {
            try
            {
                string MenuID = Request.Form["MenuID"] != "" ? Request.Form["MenuID"].ToString() : "";
                string RoleID = Request.Form["RoleID"] != "" ? Request.Form["RoleID"].ToString() : "";
                string[] arrMenuID = MenuID.Split(',');
                string writeMsg = "保存成功！";
                if (RoleID == "")
                    writeMsg = "保存失败！";
                else
                {
                    //先删除
                    bool result = true;
                    result = SysMenuDao.Instance.DeleteRoleMenu(int.Parse(RoleID));
                    foreach (string item in arrMenuID)
                    {
                        if (string.IsNullOrEmpty(item))
                            continue;
                        int menuid = int.Parse(item);
                        int nroleid = int.Parse(RoleID);
                        result = SysMenuDao.Instance.InsertRoleMenu(nroleid, menuid);
                    }
                    if (!result)
                        writeMsg = "保存失败";
                }
                return Content(writeMsg);
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
                return Content("保存失败");
            }
        }
    }
}
