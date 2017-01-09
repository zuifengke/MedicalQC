using MedQC.Web.Models;
using MedQC.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedQC.Web.Areas.MedQC.Controllers
{
    public class CheckPointController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetTreeJson()
        {

            string szJson = string.Empty;
            var result = MeddocEnterRepository.GetRepositoryEnter().QcCheckPointRepository.LoadEntities().OrderBy(m => m.OrderValue).ToList();
            szJson = JsonHelper.GetQcCheckPointTreeJson(result, -1).Replace("\n", "").Replace(@"\","");
            //szJson = "[{\"ID\":\"1\",\"Name\":\"hello1\",\"ParentID\":\"0\"},{\"ID\":\"2\",\"Name\":\"hello2\",\"ParentID\":\"1\"}]";
            return Content(szJson);
            //return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetComboxTreeJson()
        {
            string categoryCode = Request.QueryString["categorycode"];
            string szJson = string.Empty;
            var result = MeddocEnterRepository.GetRepositoryEnter().QcCheckPointRepository.LoadEntities().OrderBy(m=>m.OrderValue).ToList();
            szJson = JsonHelper.GetQcCheckPointTreeJson(result, 0);
            //szJson = "[{\"ID\":\"1\",\"Name\":\"hello1\",\"ParentID\":\"0\"},{\"ID\":\"2\",\"Name\":\"hello2\",\"ParentID\":\"1\"}]";
            return Content(szJson);
            //return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetDetail()
        {
            int id = Request.Form["id"] != "" ? int.Parse(Request.Form["id"]) : 0;
            var result = EnterRepository.GetRepositoryEnter().CategoryRepository.LoadEntities(m => m.ID == id).FirstOrDefault();
            return Json(result);
        }

        [HttpPost]
        public ActionResult Edit()
        {
            string writeMsg = string.Empty;
            Category item = new Category();
            item.ID = int.Parse(Request.Form["ID"]);
            item.Name = Request.Form["Name"];
            item.Code = Request.Form["Code"];
            item.ParentID = int.Parse(Request.Form["ParentID"]);
            EnterRepository.GetRepositoryEnter().CategoryRepository.Get(m => m.ID == item.ID);
            bool result = EnterRepository.GetRepositoryEnter().CategoryRepository.EditEntity(item, new string[] { "Name", "Code" });
            if (EnterRepository.GetRepositoryEnter().SaveChange() > 0)
            {
                writeMsg = "修改成功!";
            }
            else
            {
                writeMsg = "修改失败!";
            }
            return Content(writeMsg);
        }
        [HttpPost]
        public ActionResult Add()
        {
            string writeMsg = string.Empty;
            Category item = new Category();
            item.Name = Request.Form["Name"];
            item.Code = Request.Form["Code"];
            item.ParentID = int.Parse(Request.Form["ParentID"]);
            EnterRepository.GetRepositoryEnter().CategoryRepository.AddEntity(item);
            if (EnterRepository.GetRepositoryEnter().SaveChange() > 0)
            {
                writeMsg = "{msg:\"新增成功!\",id:" + item.ID.ToString() + "}";
            }
            else
            {
                writeMsg = "{msg:\"新增失败!\",id:0}";
            }
            return Content(writeMsg);
        }
        [HttpPost]
        public ActionResult Delete()
        {
            string writeMsg = string.Empty;
            Category item = new Category();
            item.ID = int.Parse(Request.Form["ID"]);
            EnterRepository.GetRepositoryEnter().CategoryRepository.DeleteEntity(item);
            if (EnterRepository.GetRepositoryEnter().SaveChange() > 0)
            {
                writeMsg = "删除成功";
            }
            else
            {
                writeMsg = "删除失败";
            }
            return Content(writeMsg);
        }

    }
}
