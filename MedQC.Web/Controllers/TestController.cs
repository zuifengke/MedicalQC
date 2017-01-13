using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedQC.Web.Controllers
{
    [Filters.MyException]
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        { 
            var result = IBatisAccess.ScOperationDao.Instance.QueryScOperaitonByProc(null, 0);
            return View();
        }
        [HttpPost]
        public ActionResult TestError()
        {
            return Content("");
        }

    }
}
