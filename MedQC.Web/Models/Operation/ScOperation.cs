using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web.Models
{
    public class ScOperation
    {
        public int ROWINDEX { get; set; }
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 就诊号
        /// </summary>
        public int VISIT_ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 入科时间
        /// </summary>
        public DateTime ADMISSION_DATE_TIME { get; set; }
        /// <summary>
        /// 出院时间
        /// </summary>
        public DateTime DISCHARGE_DATE_TIME { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int AGE { get; set; }
        /// <summary>
        /// 主诊医生 
        /// </summary>
        public string ATTENDING_DOCTOR { get; set; }
        /// <summary>
        /// 主要诊断
        /// </summary>
        public string MAIN_DIAGNOSIS { get; set; }
        /// <summary>
        /// 住院天数
        /// </summary>
        public int INPDAYS { get; set; }
        /// <summary>
        /// 手术序号
        /// </summary>
        public int OPERATION_NO { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_NAME { get; set; }
        /// <summary>
        /// 手术代码
        /// </summary>
        public string OPERATION_CODE { get; set; }
        /// <summary>
        /// 手术规模
        /// </summary>
        public string OPERATION_SCALE { get; set; }
        /// <summary>
        /// 手术时间
        /// </summary>
        public DateTime OPERATION_DATE_TIME { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public string CONTINUED_TIMESPAN { get; set; }
        /// <summary>
        /// 第一术者
        /// </summary>
        public string SURGEON { get; set; }
        /// <summary>
        /// 麻醉方式
        /// </summary>
        public string ANESTHESIA_METHOD { get; set; }
        /// <summary>
        /// 病情说明
        /// </summary>
        public string PATIENT_CONDITION { get; set; }
        /// <summary>
        /// 切口等级
        /// </summary>
        public string WOUND_GRADE { get; set; }
        /// <summary>
        /// 手术室代码
        /// </summary>
        public string OPERATING_CODE { get; set; }
        /// <summary>
        /// 手术室名称
        /// </summary>
        public string OPERATING_NAME { get; set; }
        /// <summary>
        /// 输血总量
        /// </summary>
        public int BLOOD_TRAN_VOL { get; set; }
        /// <summary>
        /// 会诊次数
        /// </summary>
        public int CONSULTATION_TIMES { get; set; }
        /// <summary>
        /// 抢救次数
        /// </summary>
        public int EMER_TREAT_TIMES { get; set; }
        /// <summary>
        /// 感染说明
        /// </summary>
        public string INFECTION_DIAGNOSIS { get; set; }
        /// <summary>
        /// 医疗费用
        /// </summary>
        public decimal COST { get; set; }
        /// <summary>
        /// 药品费用
        /// </summary>
        public decimal DRUG_COST { get; set; }
        /// <summary>
        /// 手术并发症
        /// </summary>
        public string COMPLICATION { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OPER_DATE_TIME { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 费别
        /// </summary>
        public string CHARGE_TYPE { get; set; }
        /// <summary>
        /// 病区代码
        /// </summary>
        public string WARD_CODE { get; set; }
        /// <summary>
        /// 病区名称
        /// </summary>
        public string WARD_NAME { get; set; }
    }
}