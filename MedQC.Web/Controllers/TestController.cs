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
            Models.OperationName operationName = new Models.OperationName();
            operationName.PATIENT_ID = "316793";
            operationName.VISIT_ID = 1;
            operationName.OPER_ID = 1;
            var operationNames= IBatisAccess.OperationNameDao.Instance.GetOperationNames(operationName);
            string opearationName = string.Join(",", (string[])operationNames.Select(m => m.OPERATION.Trim()).ToArray());
            return View();
        }
        [HttpPost]
        public ActionResult TestError()
        {
            return Content("");
        }

    }
}
