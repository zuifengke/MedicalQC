using MedQC.Web.IBatisAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedQC.Web.Areas.Operation.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Operation/Home/

        public ActionResult Index()
        {
            int id = WebCookieHelper.GetSysUserId();
            if (id == 0)
                return Redirect("/login.html");
            string url = Request.Url.AbsolutePath.ToString();
            var systems = SysMenuDao.Instance.GetSysMenus(null).Where(m => m.MenuType == "系统").ToList();
            ViewBag.sysmenu = systems.Where(m => m.Url == url).FirstOrDefault();
            ViewBag.systems = systems;
            ViewBag.name = WebCookieHelper.GetSysUserInfo(1);
            return View();
        }

        public ActionResult Test()
        {
            return View();

        }
    }
}
