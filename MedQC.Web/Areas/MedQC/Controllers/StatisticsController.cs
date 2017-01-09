using MedQC.Web.Models.Meddoc;
using MedQC.Web.OleDbAccess;
using MedQC.Web.ViewsModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MedQC.Web.Areas.MedQC.Controllers
{
    [Filters.MyException]
    public class StatisticsController : Controller
    {
        //
        // GET: /MedQC/Statistics/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Timeout()
        {
            return View();
        }
        public ActionResult TimeoutData()
        {
            try
            {
                List<DataChat> lstDataChat = QcTimeRecordServices.GetQuanyuanChaoshiLv().OrderBy(m=>m.Name).ToList();
                
                return Json(lstDataChat, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        /// <summary>
        /// 当月每个科室超时率排名
        /// </summary>
        /// <returns></returns>
        public ActionResult DeptRanking()
        {
           
            return View();
        }
        public ActionResult DeptRankingData()
        {
            try
            {
                List<DataChat> lstDataChat = QcTimeRecordServices.GetDeptRanking().OrderBy(m => m.Count).ToList();

                return Json(lstDataChat, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// 当月医生超时率排名
        /// </summary>
        /// <returns></returns>
        public ActionResult DoctorRanking()
        {
            return View();
        }
        public ActionResult DoctorRankingData()
        {
            try
            {
                List<DataChat> lstDataChat = QcTimeRecordServices.GetDoctorRanking().OrderBy(m => m.Count).ToList();

                return Json(lstDataChat, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public void Test() {

        }
       
    }
}
