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
    [Filters.MyException]
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
        public ActionResult QueryEvaluation(FormCollection form)
        {
            var PATIENT_ID = form["PATIENT_ID"].ToString();
            var VISIT_ID = int.Parse(form["VISIT_ID"].ToString());
            ScOperationEvaluation scOperationEvaluation = new ScOperationEvaluation();
            scOperationEvaluation.PATIENT_ID = PATIENT_ID;
            scOperationEvaluation.VISIT_ID = VISIT_ID;

            var scOpreation = ScOperationDao.Instance.QueryForEvaluation(PATIENT_ID, VISIT_ID).First();
            scOperationEvaluation.SEX = scOpreation.SEX;
            scOperationEvaluation.WARD_NAME = scOpreation.WARD_NAME;
            scOperationEvaluation.NAME = scOpreation.NAME;
            scOperationEvaluation.AGE = scOpreation.AGE;
            scOperationEvaluation.OPERATION_NO = scOpreation.OPERATION_NO;
            scOperationEvaluation.INPDAYS = scOpreation.INPDAYS;
            scOperationEvaluation.ATTENDING_DOCTOR = scOpreation.ATTENDING_DOCTOR;
            scOperationEvaluation.SURGEON = scOpreation.SURGEON;
            scOperationEvaluation.COST = scOpreation.COST;
            scOperationEvaluation.COMPLICATION = scOpreation.COMPLICATION;


            var operationNames = OperationNameDao.Instance.GetOperationNames(
                new OperationName() { PATIENT_ID = PATIENT_ID, VISIT_ID = VISIT_ID, OPER_ID = scOpreation.OPERATION_NO });
            if (operationNames != null)
            {
                scOperationEvaluation.OPERATIONNAME1= string.Join(",", (string[])operationNames.Select(m => m.OPERATION.Trim()).ToArray());
            }

            return Json(new { scOperationEvaluation });
        }
    }
}
