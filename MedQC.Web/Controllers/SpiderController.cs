using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedQC.Web.Controllers
{
    [Filters.MyException]
    public class SpiderController : Controller
    {
        //
        // GET: /Spider/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetHtml()
        {

            string url = Request.Form["url"];
            string htmlstr = HtmlContentHelper.WebPageContentGet(url);
            string title = HtmlContentHelper.WebPageTitleGet(htmlstr).Replace("- 今日头条(TouTiao.com)","");
            string description = HtmlContentHelper.WebPageDescriptionGet(htmlstr);
            string keywords = HtmlContentHelper.WebPageKeywordsGet(htmlstr);
            string article = HtmlContentHelper.WebPageArticleGet(htmlstr);




            var blog = EnterRepository.GetRepositoryEnter().BlogRepository.LoadEntities(m => m.ReprintUrl == url).FirstOrDefault();
            if (blog == null)
            {
                blog = new Models.Blog();
                blog.ReprintUrl = url;
                blog.MemberID = WebCookieHelper.GetUserId(0);
                blog.CategoryID = EnterRepository.GetRepositoryEnter().CategoryRepository.LoadEntities(m => m.Code == "blog").FirstOrDefault().ID;
                blog.ImagePath = HtmlContentHelper.GetFirstImgUrl(article);
                blog.IsPublic = 1;
                blog.Keywords = keywords;
                blog.Summary = description;
                blog.Zhuanzai = 1;
                blog.ModifyTime = DateTime.Now;
                blog.CreateTime = DateTime.Now;
                blog.Content = article;
                blog.Title = title;
                EnterRepository.GetRepositoryEnter().BlogRepository.AddEntity(blog);

            }
            else
            {
                blog.ReprintUrl = url;
                blog.MemberID = WebCookieHelper.GetUserId(0);
                blog.ImagePath = HtmlContentHelper.GetFirstImgUrl(article);
                blog.IsPublic = 1;
                blog.Keywords = keywords;
                blog.Summary = description;
                blog.Zhuanzai = 1;
                blog.ModifyTime = DateTime.Now;
                blog.Content = article;
                blog.Title = title;
                EnterRepository.GetRepositoryEnter().BlogRepository.EditEntity(blog,new string[] {"MemberID","Content", "IsPublic", "ReprintUrl", "Keywords"
                    , "ModifyTime", "Summary", "ImagePath", "Title","Zhuanzai"  });
                
            }
            if (EnterRepository.GetRepositoryEnter().SaveChange() > 0)
            {
                return Redirect("/blog/view/" + blog.ID + ".htm");
            }
            return Content("");
        }
        [HttpPost]
        public ActionResult SetMenuName()
        {
            string menuname = Request.Form["menuname"];
            Utility.CacheHelper.AddCache("menuname", menuname,72);
            return Redirect("/blog/index.htm");
            
        }
    }
}
