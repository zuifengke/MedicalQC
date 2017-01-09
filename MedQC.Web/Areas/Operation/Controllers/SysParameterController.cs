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
    public class SysParameterController : Controller
    {
        //
        // GET: /Operation/SysParameter/

        public ActionResult Index()
        {
            var parameters = SysParameterDao.Instance.GetChildNodesByCode(SystemConst.OperationParameter.operation);
            ViewBag.parameters = parameters;
            return View();
        }

        [HttpPost]
        public ActionResult QueryData()
        {
            var code = Request.QueryString["code"];
            var parameters = SysParameterDao.Instance.GetChildNodesByCode(code);
            return Json(parameters);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveGrid(FormCollection form)
        {
            var parent = SysParameterDao.Instance.QueryOneByCode(SystemConst.OperationParameter.two_surgical_early_warning_medical_records_filtering);
            string list = form["list"];
            JsonHelper json = new JsonHelper();
            List<Operation.Models.Parameter> lstParameter = json.Deserialize<List<Operation.Models.Parameter>>(list);
            if (lstParameter != null)
            {
                foreach (var item in lstParameter)
                {
                    if (item.Status == "insert")
                    {
                        SysParameter sysparameter = new SysParameter() { Code = item.Code, Name = item.Code, Value = item.Value, ParentID = parent.ID };
                        SysParameterDao.Instance.Insert(sysparameter);
                    }
                    else if (item.Status == "update")
                    {
                        var sysparameter = SysParameterDao.Instance.QueryOne(item.ID);
                        sysparameter.Name = item.Code;
                        sysparameter.Code = item.Code;
                        sysparameter.Value = item.Value;
                        if (string.IsNullOrEmpty(item.Code) && string.IsNullOrEmpty(item.Value))
                        {
                            SysParameterDao.Instance.Delete(item.ID);
                        }
                        else
                            SysParameterDao.Instance.Update(sysparameter);
                    }
                    else if (item.Status == "delete")
                    {
                        SysParameterDao.Instance.Delete(item.ID);
                    }
                }
            }
            string writeMsg = "{msg:\"保存成功!\"}";
            return Content(writeMsg);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form)
        {
            string writeMsg = "{msg:\"保存失败!\"}";
            var complication_keys = form[SystemConst.OperationParameter.complication_keys];
            bool result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.complication_keys, complication_keys);
            if (!result) return Content(writeMsg);

            var complication_type = form[SystemConst.OperationParameter.complication_type];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.complication_type, complication_type);
            if (!result) return Content(writeMsg);

            var filtering_characters = form[SystemConst.OperationParameter.filtering_characters];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.filtering_characters, filtering_characters);
            if (!result) return Content(writeMsg);

            var medical_history_problem = form[SystemConst.OperationParameter.medical_history_problem];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.medical_history_problem, medical_history_problem);
            if (!result) return Content(writeMsg);

            var operation_days = form[SystemConst.OperationParameter.operation_days];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.operation_days, operation_days);
            if (!result) return Content(writeMsg);

            var operation_keys_count = form[SystemConst.OperationParameter.operation_keys_count];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.operation_keys_count, operation_keys_count);
            if (!result) return Content(writeMsg);

            var operation_name_keys = form[SystemConst.OperationParameter.operation_name_keys];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.operation_name_keys, operation_name_keys);
            if (!result) return Content(writeMsg);

            var order_keywords = form[SystemConst.OperationParameter.order_keywords];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.order_keywords, order_keywords);
            if (!result) return Content(writeMsg);

            var patients_return_reason = form[SystemConst.OperationParameter.patients_return_reason];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.patients_return_reason, patients_return_reason);
            if (!result) return Content(writeMsg);

            var post_operative_warning_days = form[SystemConst.OperationParameter.post_operative_warning_days];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.post_operative_warning_days, post_operative_warning_days);
            if (!result) return Content(writeMsg);

            var temperature_degree = form[SystemConst.OperationParameter.temperature_degree];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.temperature_degree, temperature_degree);
            if (!result) return Content(writeMsg);

            var warning_condition = form[SystemConst.OperationParameter.warning_condition];
            result = SysParameterDao.Instance.ModifyValue(SystemConst.OperationParameter.warning_condition, warning_condition);
            if (!result) return Content(writeMsg);

            writeMsg = "{msg:\"保存成功!\"}";
            return Content(writeMsg);
        }

    }
}
