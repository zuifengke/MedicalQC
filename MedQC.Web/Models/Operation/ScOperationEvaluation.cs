using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web.Models
{
    public class ScOperationEvaluation
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
        /// 手术次数
        /// </summary>
        public int OPERATION_NO { get; set; }
        /// <summary>
        /// 患者目前状态
        /// </summary>
        public string PATIENT_STATUS { get; set; }
        /// <summary>
        /// 并发症发生时间
        /// </summary>
        public DateTime COMPLICATION_START_DATE { get; set; }
        /// <summary>
        /// 并发症处理时间
        /// </summary>
        public DateTime COMPLICATION_DEAL_DATE { get; set; }
        /// <summary>
        /// 主要诊断1
        /// </summary>
        public string DIAGNOSIS1 { get; set; }
        /// <summary>
        /// 主要诊断2
        /// </summary>
        public string DIAGNOSIS2 { get; set; }
        /// <summary>
        /// 主要诊断3 
        /// </summary>
        public string DIAGNOSIS3 { get; set; }
        /// <summary>
        /// 手术名称1
        /// </summary>
        public string OPERATIONNAME1 { get; set; }
        /// <summary>
        /// 手术名称2
        /// </summary>
        public string OPERATIONNAME2 { get; set; }
        /// <summary>
        /// 手术名称3
        /// </summary>
        public string OPERATIONNAME3 { get; set; }
        /// <summary>
        /// 目前治疗方案
        /// </summary>
        public string PROJECTINFO { get; set; }
        /// <summary>
        /// 诊治经过
        /// </summary>
        public string PROCESS { get; set; }
        /// <summary>
        /// 二次手术原因
        /// </summary>
        public string REASON { get; set; }
        /// <summary>
        /// 科室讨论意见和教训
        /// </summary>
        public string LESSON { get; set; }
        /// <summary>
        /// 专家评议
        /// </summary>
        public string SUGGESTION { get; set; }
        /// <summary>
        /// 评审状态 0：保存 1：已提交
        /// </summary>
        public int STATUS { get; set; }
        /// <summary>
        /// 是否二次手术 1：是 0：否
        /// </summary>
        public int OPERATION_FLAG { get; set; }
        /// <summary>
        /// 非二次手术原因
        /// </summary>
        public string REASON2 { get; set; }

        #region 扩展属性，不存数据库
        public string WARD_NAME { get; set; }
        public string NAME { get; set; }
        public string SEX { get; set; }
        public int AGE { get; set; }
        /// <summary>
        /// 住院天数
        /// </summary>
        public int INPDAYS { get; set; }
        /// <summary>
        /// 主诊医生 
        /// </summary>
        public string ATTENDING_DOCTOR { get; set; }
        /// <summary>
        /// 第一术者 主刀医师
        /// </summary>
        public string SURGEON { get; set; }
        /// <summary>
        /// 手术并发症
        /// </summary>
        public string COMPLICATION { get; set; }
        /// <summary>
        /// 医疗费用
        /// </summary>
        public decimal COST { get; set; }
        #endregion
    }
}