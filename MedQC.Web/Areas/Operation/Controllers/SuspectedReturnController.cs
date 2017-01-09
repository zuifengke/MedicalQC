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
    public class SuspectedReturnController : Controller
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
            var result =Services.OperationMasterServices.GetSuspectedReturns();
            
            return Json(new
            {
                rows = result,
                total = result.Count()
            });
        }

        [HttpPost]
        public ActionResult GetComplicationTypeComboJson()
        {
            try
            {
                string complication_type= SystemContext.Instance.OperationParameter[SystemConst.OperationParameter.complication_type];
                if (string.IsNullOrEmpty(complication_type))
                {
                    return Content("");
                }
                JsonHelper json = new JsonHelper();
                string strJson = string.Empty;
                foreach (var item in complication_type.Split(','))
                {
                    json.AddItem("ID", item);
                    json.AddItem("Name", item);
                    json.ItemOk();
                }
                //string strJson = "[{\"ID\":\"81\",\"Name\":\"jxdhlgljp\",\"Desc\":\"jxdhlgljp\"},{\"ID\":\"82\",\"Name\":\"hhh\",\"Desc\":\"jxdhlgljp\"}]";
                return Content(json.ToEasyuiListJsonString());
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
                throw;
            }
        }
        [HttpPost]
        public JsonResult Save(FormCollection form)
        {
            ViewsModels.Result result = new ViewsModels.Result();
         
            string PATIENT_ID = form["PATIENT_ID"];
            string VISIT_ID = form["VISIT_ID"];
            string COMPLICATION = form["COMPLICATION"];
            string MEMO = form["MEMO"];
            //查询确认过的二次手术患者信息
            var list = IBatisAccess.OperationMasterDao.Instance.GetSuspectedReturns(PATIENT_ID, VISIT_ID).ToList();
            DateTime OPER_DATE_TIME = DateTime.Now;
            foreach (var item in list)
            {
                item.CONTINUED_TIMESPAN = TimeHelper.GetTimeSpanMin(item.START_DATE_TIME, item.END_DATE_TIME);
               ScOperation scOperation = new ScOperation();
                scOperation.ADMISSION_DATE_TIME = item.ADMISSION_DATE_TIME;
                scOperation.AGE = item.AGE;
                scOperation.ANESTHESIA_METHOD = item.ANESTHESIA_METHOD;
                scOperation.ATTENDING_DOCTOR = item.ATTENDING_DOCTOR;
                scOperation.BLOOD_TRAN_VOL = item.BLOOD_TRAN_VOL;
                scOperation.CHARGE_TYPE = item.CHARGE_TYPE;
                scOperation.COMPLICATION = COMPLICATION;
                scOperation.CONSULTATION_TIMES = item.CONSULTATION_TIMES;
                scOperation.CONTINUED_TIMESPAN = item.CONTINUED_TIMESPAN;
                scOperation.COST = item.COST;
                scOperation.DEPT_CODE = item.DEPT_CODE;
                scOperation.DEPT_NAME = item.DEPT_NAME;
                scOperation.DISCHARGE_DATE_TIME = item.DISCHARGE_DATE_TIME;
                scOperation.DRUG_COST = item.DRUG_COST;
                scOperation.EMER_TREAT_TIMES = item.EMER_TREAT_TIMES;
                scOperation.INFECTION_DIAGNOSIS = item.INFECTIONMEMO;
                scOperation.INPDAYS = item.INPDAYS;
                scOperation.MAIN_DIAGNOSIS = item.DIAGNOSIS_DESC;
                scOperation.MEMO = MEMO;
                scOperation.NAME = item.NAME;
                scOperation.OPERATING_NAME = item.OPROOM;
                scOperation.OPERATING_CODE = item.OPERATING_ROOM;
                scOperation.OPERATION_DATE_TIME = item.START_DATE_TIME;
                scOperation.OPERATION_CODE = item.OPERATION_CODE;
                scOperation.OPERATION_NAME = item.OPERATION_NAME;
                scOperation.OPERATION_NO = item.OPER_ID;
                scOperation.OPERATION_SCALE = item.OPERATION_SCALE;
                scOperation.OPER_DATE_TIME = OPER_DATE_TIME;
                scOperation.PATIENT_CONDITION = item.PATIENT_CONDITION;
                scOperation.PATIENT_ID = item.PATIENT_ID;
                scOperation.SEX = item.SEX;
                scOperation.SURGEON = item.SURGEON;
                scOperation.VISIT_ID = item.VISIT_ID;
                scOperation.WARD_CODE = item.WARD_CODE;
                scOperation.WARD_NAME = item.WARD_NAME;
                scOperation.WOUND_GRADE = item.WOUND_GRADE;
                bool ret= ScOperationDao.Instance.Insert(scOperation);
                if (!ret)
                {
                    result.message = "操作失败";
                    result.status = "false";
                    break;
                }
            }
            return Json(result);
        }
    }
}
