using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedQC.Web.Utility;
using MedQC.Web.Models;
using MedQC.Web.Filters;
using MedQC.Web.IBatisAccess;
using MedQC.Web.Services;

namespace MedQC.Web.Areas.SysConfig.Controllers
{
    [MyException]
    public class SysUserController : Controller
    {
        //
        // GET: /SysConfig/SysUser/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QueryData()
        {
            int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            string Name = Request.Form["Name"] != null ? Request.Form["Name"] : "";
            string Tel = Request.Form["Tel"] != null ? Request.Form["Tel"] : "";
            SysUser sysUser = new SysUser() { Name = Name, Tel = Tel };
            if (page < 1) return Content("");
            var lstSysUser = SysUserDao.Instance.LoadPageList(page, size, sysUser).ToList();

            JsonHelper json = new JsonHelper();
            string strJson = string.Empty;
            foreach (SysUser item in lstSysUser)
            {
                json.AddItem("ID", item.ID.ToString());
                json.AddItem("LoginName", item.LoginName);
                json.AddItem("Password", item.Password);
                json.AddItem("Name", item.Name);
                json.AddItem("Tel", item.Tel);
                item.RoleNames = SysUserServices.GetRoleNames(item.ID);
                json.AddItem("RoleNames", item.RoleNames);
                json.ItemOk();
            }

            json.totlalCount = SysUserDao.Instance.GetTotalCount(sysUser);
            if (json.totlalCount > 0)
            {
                strJson = json.ToEasyuiGridJsonString();
            }
            else
            {
                strJson = @"[]";
            }
            return Content(strJson);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public ActionResult Delete()
        {
            bool success = true;

            string ids = Request.Form["ids"] != "" ? Request.Form["ids"] : "";
            if (ids != string.Empty && ids != "0")
            {
                string[] arrids = ids.Split(',');
                foreach (var item in arrids)
                {
                    int id = int.Parse(item);
                    bool result = SysUserDao.Instance.Delete(id);
                    if (!result)
                    {
                        result = false;
                        break;
                    }
                    success = true;
                }
            }
            if (success)
                return Json(new
                {
                    success = "true",
                    errorMsg = ""
                });
            else
                return Json(new
                {
                    success = "false",
                    errorMsg = "删除失败"
                });
        }

        #region 添加或修改提交的数据

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Insert(FormCollection form)
        {
            string writeMsg = string.Empty;
            SysUser item = new SysUser();
            item.LoginName = Request.Form["LoginName"] != "" ? Request.Form["LoginName"] : "";
            item.Password = MD5Helper.MD5(SystemContext.Instance.DefaultPwd);
            item.Name = Request.Form["Name"] != "" ? Request.Form["Name"] : "";
            item.Tel = Request.Form["Tel"] != "" ? Request.Form["Tel"] : "";
            item.RoleIDs = Request.Form["RoleIDs[]"] != "" ? Request.Form["RoleIDs[]"] : "";
            bool result = SysUserDao.Instance.Insert(item);
            if (result)
            {
                if (!string.IsNullOrEmpty(item.RoleIDs))
                {
                    string[] roleIds = item.RoleIDs.Split(',');
                    foreach (var id in roleIds)
                    {
                        if (id == "")
                            continue;
                        int nid = int.Parse(id);
                        result = SysUserDao.Instance.InsertUserRole(item.ID, nid);
                    }
                }
                writeMsg = "{msg:\"保存成功!\",id:" + item.ID.ToString() + "}";
            }
            else
            {
                writeMsg = "{msg:\"保存失败!\",id:0}";
            }
            return Content(writeMsg);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(FormCollection form)
        {
            string writeMsg = string.Empty;
            SysUser item = new SysUser();
            item.ID = int.Parse(Request.QueryString["ID"]);
            item = SysUserDao.Instance.QueryOne(item.ID);
            item.LoginName = Request.Form["LoginName"] != "" ? Request.Form["LoginName"] : "";
            item.Name = Request.Form["Name"] != "" ? Request.Form["Name"] : "";
            item.Tel = Request.Form["Tel"] != "" ? Request.Form["Tel"] : "";
            item.RoleIDs = Request.Form["RoleIDs"] != "" ? Request.Form["RoleIDs"] : "";
            bool result = SysUserDao.Instance.Update(item);
            if (result)
            {
                result = SysUserDao.Instance.DeleteUserRole(item.ID);
                if (!string.IsNullOrEmpty(item.RoleIDs))
                {
                    string[] roleIds = item.RoleIDs.Split(',');
                    foreach (var id in roleIds)
                    {
                        if (id == "")
                            continue;
                        int nid = int.Parse(id);
                        result = SysUserDao.Instance.InsertUserRole(item.ID, nid);
                    }
                }
                writeMsg = "{msg:\"保存成功!\",id:" + item.ID.ToString() + "}";
            }
            else
            {
                writeMsg = "{msg:\"保存失败!\",id:" + item.ID.ToString() + "}";
            }
            return Content(writeMsg);
        }
        /// <summary>
        /// 密码重置为111111
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ResetPassword(SysUser item)
        {
            if (item.ID == 0)
                return Content("密码重置失败");
            string writeMsg = string.Empty;
            item.Password = MD5Helper.MD5(SystemContext.Instance.DefaultPwd);
            bool result= SysUserDao.Instance.ResetPassword(item);
            if (result)
            {
                writeMsg = "密码重置成功!";
            }
            else
            {
                writeMsg = "密码重置失败";
            }
            return Content(writeMsg);
        }
        //#endregion
        /// <summary>
        /// 获取指定ID的数据
        /// </summary>
        public ActionResult GetDetail()
        {
            int id = Request.Form["id"] != "" ? int.Parse(Request.Form["id"]) : 0;
            var item = SysUserDao.Instance.QueryOne(id);
            item.RoleIDs = SysUserServices.GetRoleIDs(item.ID);
            return Json(item);
        }
        [HttpPost]
        public ActionResult QueryRoleComboJson()
        {
            try
            {

                var result = SysRoleDao.Instance.GetSysRoles(null).ToList();
                //return Json(new
                //{
                //    result
                //}, JsonRequestBehavior.AllowGet);
                JsonHelper json = new JsonHelper();
                string strJson = string.Empty;
                foreach (var item in result)
                {
                    json.AddItem("ID", item.ID.ToString());
                    json.AddItem("Name", item.Name);
                    json.ItemOk();
                }

                //string strJson = "[{\"ID\":\"81\",\"Name\":\"jxdhlgljp\",\"Desc\":\"jxdhlgljp\"},{\"ID\":\"82\",\"Name\":\"hhh\",\"Desc\":\"jxdhlgljp\"}]";
                return Content(json.ToEasyuiListJsonString());
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
                throw;
            }
        }
    }

}

#endregion