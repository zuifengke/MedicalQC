using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web.Models
{
    public class OperationName
    {
        /// <summary>
        /// 患者ID号
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 入院次
        /// </summary>
        public int VISIT_ID { get; set; }
        /// <summary>
        /// 病人本次手术标识
        /// </summary>
        public int OPER_ID { get; set; }
        /// <summary>
        /// 病人本次手术中的第几个手术
        /// </summary>
        public int OPERATION_NO { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION { get; set; }
        /// <summary>
        /// 手术代码
        /// </summary>
        public string OPERATION_CODE { get; set; }
        /// <summary>
        /// 手术等级
        /// </summary>
        public string OPERATION_SCALE { get; set; }
        /// <summary>
        /// 切口等级
        /// </summary>
        public string WOUND_GRADE { get; set; }
        /// <summary>
        /// 手术申请号
        /// </summary>
        public int? SERIAL_NO { get; set; }
    }
}