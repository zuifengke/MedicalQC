using MedQC.Web.Models.Meddoc;
using MedQC.Web.OleDbAccess;
using MedQC.Web.Utility;
using MedQC.Web.ViewsModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MedQC.Web.Areas.MedQC.Controllers
{
    [Filters.MyException]
    public class QcArticleController : Controller
    {
        //
        // GET: /MedQC/Statistics/

        public ActionResult Index()
        {
            string categoryCode = Request.QueryString["CategoryCode"];
            ViewBag.CategoryCode = categoryCode;
            return View();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        public ActionResult QueryData()
        {
            int page = Request.Form["page"] != "" ? Convert.ToInt32(Request.Form["page"]) : 0;
            int size = Request.Form["rows"] != "" ? Convert.ToInt32(Request.Form["rows"]) : 0;
            string sort = Request.Form["sort"] != "" ? Request.Form["sort"] : "";
            string order = Request.Form["order"] != "" ? Request.Form["order"] : "";
            string title = Request.Form["Title"] != "" ? Request.Form["Title"] : "";
            string categoryCode = Request.Form["CategoryCode"] != null ?Request.Form["CategoryCode"] : "";
            string keywords = Request.Form["keywords"] != null ? Request.Form["keywords"] : "";
            if (page < 1) return Content("");
            int totalCount = 0;
            var result = MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.LoadPageList(title, 0, categoryCode, keywords, (page - 1) * size, size, out totalCount).ToList();

            JsonHelper json = new JsonHelper();
            string strJson = string.Empty;
            foreach (QcArticle item in result)
            {
                json.AddItem("ID", item.ID.ToString());
                json.AddItem("Title", item.Title);
                json.AddItem("CategoryCode", item.CategoryCode);
                json.AddItem("ImagePath", item.ImagePath);
                json.AddItem("Summary", item.Summary==null?"":item.Summary.Replace("\n", "").Replace("\r", "").Replace("\t", ""));
                json.AddItem("Keywords", item.Keywords);
                json.AddItem("CategoryName", SystemConst.CategoryCode.GetCategoryName(item.CategoryCode));
                json.AddItem("CreateTime", item.CreateTime == null ? "" : item.CreateTime.ToString("yyyy-MM-dd HH:mm"));
                json.AddItem("ModifyTime", item.ModifyTime == null ? "" : item.ModifyTime.ToString("yyyy-MM-dd HH:mm"));
                json.AddItem("Content", HtmlContentHelper.GetSummary( item.Content).Replace("\n","").Replace("\r","").Replace("\t",""));
                json.ItemOk();
            }
            json.totlalCount = totalCount;
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
        [HttpPost]
        public ActionResult GetDetail()
        {
            int id = Request.Form["id"] != "" ? int.Parse(Request.Form["id"]) : 0;
            var result = MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.LoadEntities(m => m.ID == id).FirstOrDefault();
            return Json(result);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(FormCollection form)
        {
            string writeMsg = string.Empty;
            QcArticle item = new QcArticle();
            item.ID = item.GetNextID();
            item.Title = Request.Form["Title"];
            item.Keywords = Request.Form["Keywords"];
            item.CategoryCode = Request.Form["CategoryCode"];
            item.Content = form["Content"];
            item.ImagePath = HtmlContentHelper.GetFirstImgUrl(item.Content);
            item.Summary = HtmlContentHelper.GetSummary(item.Content);
            item.CreateTime = DateTime.Now;
            item.ModifyTime = DateTime.Now;
            MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.AddEntity(item);
            if (MeddocEnterRepository.GetRepositoryEnter().SaveChange() > 0)
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
        public ActionResult Edit(FormCollection form)
        {
            string writeMsg = string.Empty;
            QcArticle item = new QcArticle();
            item.ID = int.Parse(Request.QueryString["ID"]);
            item.Title = Request.Form["Title"];
            item.Keywords = Request.Form["Keywords"];
            item.CategoryCode = Request.Form["CategoryCode"];
            item.Content = form["Content"];
            item.ImagePath = HtmlContentHelper.GetFirstImgUrl(item.Content);
            item.Summary = HtmlContentHelper.GetSummary(item.Content);
            item.ModifyTime = DateTime.Now;

            MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.Get(m => m.ID == item.ID);
            bool result = MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.EditEntity(item
                , new string[] { "Title", "Content", "ModifyTime", "CategoryCode","ImagePath","Summary","Keywords" });
            if (MeddocEnterRepository.GetRepositoryEnter().SaveChange() > 0)
            {
                writeMsg = "{msg:\"保存成功!\",id:" + item.ID.ToString() + "}";
            }
            else
            {
                writeMsg = "{msg:\"保存失败!\",id:" + item.ID.ToString() + "}";
            }
            return Content(writeMsg);
        }
        [HttpPost]
        public ActionResult Delete()
        {
            bool success = false;

            string ids = Request.Form["ids"] != "" ? Request.Form["ids"] : "";
            if (ids != string.Empty && ids != "0")
            {
                string[] arrids = ids.Split(',');
                foreach (var item in arrids)
                {
                    int id = int.Parse(item);
                    MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.DeleteEntity(new QcArticle() { ID = id });
                }
                //short shRet = SystemContext.Instance.EmployeeService.Delete(selectID);
                if (MeddocEnterRepository.GetRepositoryEnter().SaveChange() > 0)
                {
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
    }
}
