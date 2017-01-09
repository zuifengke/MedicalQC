using MedQC.Web.IBatisAccess;
using MedQC.Web.Models;
using MedQC.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedQC.Web.Areas.Operation.Controllers
{
    public class ReturnRoomController : Controller
    {
        //
        // GET: /Operation/ReturnRoom/

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
            var result = ScOperationDao.Instance.GetReturnRoom().ToList();
            
            return Json(new
            {
                rows = result,
                total = result.Count()
            });
        }
    }
}
