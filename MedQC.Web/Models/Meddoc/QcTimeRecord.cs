using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models.Meddoc
{

    public class QcTimeRecord
    {
        public string RuleID { get; set; }
        public string PatientID { get; set; }
        public string VisitID { get; set; }
        public string EventID { get; set; }
        public string DocTypeID { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Point { get; set; }
        public string CheckName { get; set; }
        public DateTime CheckDate { get; set; }
        public string DocID { get; set; }
        public string DocTitle { get; set; }
        public int RecNo { get; set; }
        public DateTime RecordTime { get; set; }
        public string QcResult{get;set;}
        public string CreateID { get; set; }
        public string CreateName { get; set; }
        public string QcExplain { get; set; }
        public string DoctorInCharge { get; set; }
        public string DeptInCharge { get; set; }
        public string DeptStayed { get; set; }
        public string PatientName { get; set; }
        public string DocTypeName { get; set; }
        public string EventName { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime DocTime { get; set; }
        public DateTime DischargeTime { get; set; }
        public int MessageNotify { get; set; }
        public string IsVeto { get; set; }
    }
}