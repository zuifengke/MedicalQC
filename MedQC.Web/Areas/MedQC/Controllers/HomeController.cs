using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MedQC.Web.Areas.MedQC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /MedQC/Home/
        public ActionResult Index()
        {
            string system = Request.QueryString["system"];
            if (!string.IsNullOrEmpty(system))
            {
                system = System.Web.HttpUtility.UrlEncode(system, Encoding.UTF8);
                Utility.CookieHelper.SetCookie("system", system, string.Empty, 15);
            }
            else
            {
                system = Utility.CookieHelper.GetCookie("system");
                if (system == null)
                {
                    system = System.Web.HttpUtility.UrlEncode("医疗质量管理平台", Encoding.UTF8);
                    Utility.CookieHelper.SetCookie("system", system, string.Empty, 15);
                }
            }
            ViewBag.system = system;
            return View();
        }
        public ActionResult Config()
        {
            return View();
        }
    }
}
