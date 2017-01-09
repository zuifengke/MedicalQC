using System;
using System.Collections.Generic;
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
    public class SysRoleController : Controller
    {
        //
        // GET: /SysConfig/SysRole/

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
            SysRole sysRole = new SysRole() {  Name=Name};
            if (page < 1) return Content("");
            var lstSysRole = SysRoleDao.Instance.LoadPageList(page,size, sysRole).ToList();

            JsonHelper json = new JsonHelper();
            string strJson = string.Empty;
            foreach (SysRole item in lstSysRole)
            {
                json.AddItem("ID", item.ID.ToString());
                json.AddItem("Name", item.Name);
                json.AddItem("Description", item.Description == null ? string.Empty : item.Description);
                //item.RoleNames = SysRoleServices.GetRoleNames(item.ID);
                //json.AddItem("RoleNames", item.RoleNames);
                json.ItemOk();
            }

            json.totlalCount = SysRoleDao.Instance.GetTotalCount( sysRole);
            if (json.totlalCount > 0)
            {
                strJson = json.ToEasyuiGridJsonString();
            }
            else
            {
                strJson = @"[]";
            }
            // json = "{ \"rows\":[ { \"ID\":\"48\",\"NewsTitle\":\"mr\",\"NewsContent\":\"mrsoft\",\"CreateTime\":\"2013-12-23\",\"CreateRole\":\"ceshi\",\"ModifyTime\":\"2013-12-23\",\"ModifyRole\":\"ceshi\"} ],\"total\":3}";
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
                    bool result = SysRoleDao.Instance.Delete(id);
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
            SysRole item = new SysRole();
            item.Name = Request.Form["Name"] != "" ? Request.Form["Name"] : "";
            item.Description = Request.Form["Description"] != "" ? Request.Form["Description"] : "";
            bool result = SysRoleDao.Instance.Insert(item);
            if (result)
            {
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
            SysRole item = new SysRole();
            item.ID = int.Parse(Request.QueryString["ID"]);
            item = SysRoleDao.Instance.QueryOne(item.ID);
            item.Name = Request.Form["Name"] != "" ? Request.Form["Name"] : "";
            item.Description = Request.Form["Description"] != "" ? Request.Form["Description"] : "";
            bool result = SysRoleDao.Instance.Update(item);
            if (result)
            {
                writeMsg = "{msg:\"保存成功!\",id:" + item.ID.ToString() + "}";
            }
            else
            {
                writeMsg = "{msg:\"保存失败!\",id:" + item.ID.ToString() + "}";
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
            var item = SysRoleDao.Instance.QueryOne(id);
            return Json(item);
        }
    }

}

#endregion