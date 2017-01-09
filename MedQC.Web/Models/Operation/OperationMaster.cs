using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web.Models
{
    public class OperationMaster
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 就诊号
        /// </summary>
        public int VISIT_ID { get; set; }
        /// <summary>
        /// 病人本次手术标识
        /// </summary>
        public int OPER_ID { get; set; }
        /// <summary>
        /// 病人所在科室
        /// </summary>
        public string DEPT_STAYED { get; set; }
        /// <summary>
        /// 手术室
        /// </summary>
        public string OPERATING_ROOM { get; set; }
        /// <summary>
        /// 手术间
        /// </summary>
        public string OPERATING_ROOM_NO { get; set; }
        /// <summary>
        /// 术前诊断
        /// </summary>
        public string DIAG_BEFORE_OPERATION { get; set; }
        /// <summary>
        /// 病情说明
        /// </summary>
        public string PATIENT_CONDITION { get; set; }
        /// <summary>
        /// 手术等级
        /// </summary>
        public string OPERATION_SCALE { get; set; }
        /// <summary>
        /// 术后诊断 
        /// </summary>
        public string DIAG_AFTER_OPERATION { get; set; }
        /// <summary>
        /// 急诊标志
        /// </summary>
        public int EMERGENCY_INDICATOR { get; set; }
        /// <summary>
        /// 隔离标志
        /// </summary>
        public int ISOLATION_INDICATOR { get; set; }
        /// <summary>
        /// 手术类型
        /// </summary>
        public string OPERATION_CLASS { get; set; }
        /// <summary>
        /// 手术科室
        /// </summary>
        public string OPERATING_DEPT { get; set; }
        /// <summary>
        /// 手术者
        /// </summary>
        public string SURGEON { get; set; }
        /// <summary>
        /// 第一手术助手
        /// </summary>
        public string FIRST_ASSISTANT { get; set; }
        /// <summary>
        /// 第二手术助手
        /// </summary>
        public string SECOND_ASSISTANT { get; set; }
        /// <summary>
        /// 第三手术助手
        /// </summary>
        public string THIRD_ASSISTANT { get; set; }
        /// <summary>
        /// 第四手术助手
        /// </summary>
        public string FOURTH_ASSISTANT { get; set; }
        /// <summary>
        /// 麻醉方式
        /// </summary>
        public string ANESTHESIA_METHOD { get; set; }
        /// <summary>
        /// 麻醉医师
        /// </summary>
        public string ANESTHESIA_DOCTOR { get; set; }
        /// <summary>
        /// 麻醉助手
        /// </summary>
        public string ANESTHESIA_ASSISTANT { get; set; }
        /// <summary>
        /// 输血者
        /// </summary>
        public string BLOOD_TRAN_DOCTOR { get; set; }
        /// <summary>
        /// 第一台上护士
        /// </summary>
        public string FIRST_OPERATION_NURSE { get; set; }
        /// <summary>
        /// 第二台上护士
        /// </summary>
        public string SECOND_OPERATION_NURSE { get; set; }
        /// <summary>
        /// 第一供应护士
        /// </summary>
        public string FIRST_SUPPLY_NURSE { get; set; }
        /// <summary>
        /// 第二供应护士
        /// </summary>
        public string SECOND_SUPPLY_NURSE { get; set; }
        /// <summary>
        /// 护士术中换班标志
        /// </summary>
        public int NURSE_SHIFT_INDICATOR { get; set; }
        /// <summary>
        /// 手术开始时间
        /// </summary>
        public DateTime START_DATE_TIME { get; set; }
        /// <summary>
        /// 手术结束时间
        /// </summary>
        public DateTime END_DATE_TIME { get; set; }
        /// <summary>
        /// 麻醉满意程度
        /// </summary>
        public int SATISFACTION_DEGREE { get; set; }
        /// <summary>
        /// 手术过程顺利标志
        /// </summary>
        public int SMOOTH_INDICATOR { get; set; }
        /// <summary>
        /// 总入量
        /// </summary>
        public int IN_FLUIDS_AMOUNT { get; set; }
        /// <summary>
        /// 总出量
        /// </summary>
        public int OUT_FLUIDS_AMOUNT { get; set; }
        /// <summary>
        /// 失血量
        /// </summary>
        public int BLOOD_LOSSED { get; set; }
        /// <summary>
        /// 输血量
        /// </summary>
        public int BLOOD_TRANSFERED { get; set; }
        /// <summary>
        /// 录入者
        /// </summary>
        public string ENTERED_BY { get; set; }
        /// <summary>
        /// 麻醉开始日期及时间
        /// </summary>
        public DateTime? ANES_START_DATE_TIME { get; set; }
        /// <summary>
        /// 病人出手术室时间
        /// </summary>
        public DateTime? RETURN_DATE_TIME { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime? ENTER_DATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ARRIVE_DATE_TIME { get; set; }
        /// <summary>
        /// 手术申请号
        /// </summary>
        public int SERIAL_NO { get; set; }
        /// <summary>
        /// 手术时间
        /// </summary>
        public DateTime? SCHEDULED_DATE_TIME { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? REQ_DATE_TIME { get; set; }
        /// <summary>
        /// 台次
        /// </summary>
        public int SEQUENCE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string NOTES_ON_OPERATION { get; set; }
        /// <summary>
        /// 申请人员
        /// </summary>
        public string REQ_BY { get; set; }

        /*非表结构扩展的属性*/
        public string DEPT_CODE { get; set; }
        public string DEPT_NAME { get; set; }
        public string WARD_NAME { get; set; }
        public string WARD_CODE { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string NAME { get; set; }
        public string OPERATION_CODE { get; set; }
        public string CHARGE_TYPE { get; set; }
        /// <summary>
        /// 入院时间
        /// </summary>
        public DateTime ADMISSION_DATE_TIME { get; set; }
        /// <summary>
        /// 出院时间
        /// </summary>
        public DateTime DISCHARGE_DATE_TIME { get; set; }
        public string SEX { get; set; }
        public int AGE { get; set; }
        /// <summary>
        /// 主治医师
        /// </summary>
        public string ATTENDING_DOCTOR { get; set; }
        /// <summary>
        /// 入院主诊断
        /// </summary>
        public string DIAGNOSIS_DESC { get; set; }
        public string OPERATION_NAME { get; set; }
        public int INPDAYS { get; set; }
        public int BLOOD_TRAN_VOL { get; set; }
        public int CONSULTATION_TIMES { get;set;}

        /// <summary>
        /// 抢救次数
        /// </summary>
        public int EMER_TREAT_TIMES { get; set; }
        /// <summary>
        /// 切口等级
        /// </summary>
        public string WOUND_GRADE { get; set; }
        /// <summary>
        /// 床位号
        /// </summary>
        public string BED_NO { get; set; }
        /// <summary>
        /// 手术室名称
        /// </summary>
        public string OPROOM { get; set; }
        public string INFECTIONMEMO { get; set; }
        /// <summary>
        /// 药费
        /// </summary>
        public decimal DRUG_COST { get; set; }
        /// <summary>
        /// 总费用
        /// </summary>
        public decimal COST { get; set; }
        /// <summary>
        /// 并发症
        /// </summary>
        public string COMPLICATION { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public string CONTINUED_TIMESPAN { get; set; }
    }
}