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
    public class BlogController : Controller
    {
        public ActionResult AA() {
            ViewBag.Test = "aaa";
            return View();
        }
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
            string mine= string.IsNullOrEmpty(Request.QueryString["mine"])
               ? "false" : Request.QueryString["mine"];
           
            string categoryCode = string.IsNullOrEmpty(Request.QueryString["CategoryCode"])
               ? SystemConst.CategoryCode.Blog : Request.QueryString["CategoryCode"];
            string order = string.IsNullOrEmpty(Request.QueryString["order"])
                ? "default" : Request.QueryString["order"];
            
            int memberID=0;
            if (mine == "true")
            {
                memberID = WebCookieHelper.GetUserId(0);
                if (memberID == 0)
                    return Redirect("/member/login?returnurl=" + Request.Url);
            }
            string categoryName = EnterRepository.GetRepositoryEnter().CategoryRepository.LoadEntities(m => m.Code == categoryCode).FirstOrDefault().Name;
            Pagination pagination = new Pagination();
            int page = 1;
            if (id != null)
                page = int.Parse(id.ToString());
           
            int totalCount = 0;
            pagination.ActionUrl= "blog/index";
           
            pagination.CurrentPageIndex = page;
            var myblogs = BlogServices.GetBlogs(memberID,categoryCode, order, page, pagination.Size, out totalCount);
            pagination.TotalCount = totalCount;
            pagination.Order = order;
            pagination.CategoryCode = categoryCode;
            pagination.CategoryName = categoryName;
            ViewBag.mine = mine;
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
        /// 浏览文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult View(int id)
        {
            var blog = BlogServices.GetBlog(id);
            blog.ViewCount++;
            EnterRepository.GetRepositoryEnter().BlogRepository.EditEntity(blog, new string[] { "ViewCount" });
            EnterRepository.GetRepositoryEnter().SaveChange();
            var next = EnterRepository.GetRepositoryEnter().BlogRepository.LoadEntities(m => m.ModifyTime > blog.ModifyTime).FirstOrDefault();
            var pre = EnterRepository.GetRepositoryEnter().BlogRepository.LoadEntities(m => m.ModifyTime < blog.ModifyTime).OrderByDescending(m=>m.ModifyTime).FirstOrDefault();
            ViewBag.Next = next;
            ViewBag.Pre = pre;
            DateTime date = DateTime.Now.AddMonths(-1);
            var others = EnterRepository.GetRepositoryEnter().BlogRepository.LoadEntities(m => m.ModifyTime > date).OrderByDescending(m => m.ViewCount).Take(4).ToList();
            ViewBag.others = others;
            return View(blog);
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
