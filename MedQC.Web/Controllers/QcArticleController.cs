using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedQC.Web.Filters;
using MedQC.Web.ViewsModels;
namespace MedQC.Web.Controllers
{
    [MyException]
    public class QcArticleController : Controller
    {
        //
        // GET: /Advise/
        
        public ActionResult Write(int? id)
        {
            int memberID = WebCookieHelper.GetUserId(0);
            if (memberID==0)
                return Redirect("/member/login?returnurl=" + Request.Url);

            var blog = new Models.Blog();
            if (id != null)
                blog = EnterRepository.GetRepositoryEnter().BlogRepository.LoadEntities(m => m.ID == id).FirstOrDefault();
            else
                blog.IsPublic = 1;
            var categorylist = EnterRepository.GetRepositoryEnter().CategoryRepository.GetCategorys("blog").ToList();
            ViewBag.categorylist = categorylist;
            return View(blog);
        }
        public ActionResult Index(int? id)
        {
            string categoryCode = string.IsNullOrEmpty(Request.QueryString["CategoryCode"])
               ? SystemConst.CategoryCode.Blog : Request.QueryString["CategoryCode"];
            string order = string.IsNullOrEmpty(Request.QueryString["order"])
                ? "default" : Request.QueryString["order"];
            
            int memberID=0;
          
            string categoryName = SystemConst.CategoryCode.GetCategoryName(categoryCode);
            Pagination pagination = new Pagination();
            int page = 1;
            if (id != null)
                page = int.Parse(id.ToString());
           
            int totalCount = 0;
            pagination.ActionUrl= "qcarticle/index";
            
            pagination.CurrentPageIndex = page;
            var myblogs = QcArticleServices.GetQcArticles(memberID,categoryCode, order, page, pagination.Size, out totalCount);
            pagination.TotalCount = totalCount;
            pagination.Order = order;
            pagination.CategoryCode = categoryCode;
            pagination.CategoryName = categoryName;
            ViewBag.myblogs = myblogs;
            ViewBag.Pagination = pagination;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Write(FormCollection form)
        {
            var blog = new Models.Blog();
            blog.ID = int.Parse(form["ID"]);
            blog.CategoryID = int.Parse(form["CategoryID"]);
            blog.Content = form["Content"];
            blog.IsPublic = int.Parse(form["IsPublic"]);
            blog.Keywords = form["Keywords"];
            blog.ReprintUrl = form["ReprintUrl"];
            blog.Title = form["Title"];

            blog.Zhuanzai = int.Parse(form["Zhuanzai"]);

            blog.MemberID = WebCookieHelper.GetUserId(0);
            blog.Summary = HtmlContentHelper.GetSummary(blog.Content);
            blog.ImagePath = HtmlContentHelper.GetFirstImgUrl(blog.Content);
            //创建会员信息
            if (blog.ID == 0)
            {
                blog.CreateTime = DateTime.Now;
                blog.ModifyTime = DateTime.Now;
                EnterRepository.GetRepositoryEnter().BlogRepository.AddEntity(blog);
            }
            else {
                blog.ModifyTime = DateTime.Now;
                EnterRepository.GetRepositoryEnter().BlogRepository.Get(m => m.ID == blog.ID);
                EnterRepository.GetRepositoryEnter().BlogRepository.EditEntity(blog
                    , new string[] { "Content", "IsPublic", "ReprintUrl", "Keywords" 
                    , "ModifyTime", "Summary", "ImagePath", "CategoryID","Title","Zhuanzai" });
               
            }
            if (EnterRepository.GetRepositoryEnter().SaveChange() <= 0)
            {
                return Content("error");
            }
            return Content(blog.ID.ToString());
        }
        /// <summary>
        /// 浏览学习平台的文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult View(int id)
        {
            var item = QcArticleServices.GetQcArticle(id);
            item.ViewCount++;
            MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.EditEntity(item, new string[] { "ViewCount" });
            MeddocEnterRepository.GetRepositoryEnter().SaveChange();
            var next = MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.LoadEntities(m => m.ModifyTime > item.ModifyTime).FirstOrDefault();
            var pre = MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.LoadEntities(m => m.ModifyTime < item.ModifyTime).OrderByDescending(m=>m.ModifyTime).FirstOrDefault();
            ViewBag.Next = next;
            ViewBag.Pre = pre;
            DateTime date = DateTime.Now.AddMonths(-1);
            var others = MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.LoadEntities(m => m.ModifyTime > date).OrderByDescending(m => m.ViewCount).Take(4).ToList();
            ViewBag.others = others;
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            string mine = string.IsNullOrEmpty(Request.QueryString["mine"])
               ? "false" : Request.QueryString["mine"];
            string pageindex = string.IsNullOrEmpty(Request.QueryString["pageindex"])
               ? "1" : Request.QueryString["pageindex"];
            string categoryCode = string.IsNullOrEmpty(Request.QueryString["CategoryCode"])
               ? SystemConst.CategoryCode.Blog : Request.QueryString["CategoryCode"];
            string order = string.IsNullOrEmpty(Request.QueryString["order"])
                ? "default" : Request.QueryString["order"];

            var blog = EnterRepository.GetRepositoryEnter().BlogRepository.LoadEntities(m => m.ID == id).FirstOrDefault();
            EnterRepository.GetRepositoryEnter().BlogRepository.DeleteEntity(blog);
            int result = EnterRepository.GetRepositoryEnter().SaveChange();
            return Redirect("/blog/index/"+pageindex+"?mine="+mine+"&categorycode="+categoryCode+ "&order="+order);
        }
    }
}
