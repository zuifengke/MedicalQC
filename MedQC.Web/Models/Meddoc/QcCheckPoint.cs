using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models.Meddoc
{
    [Table("QC_CHECK_POINT")]
    public class QcCheckPoint
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CHECK_POINT_ID")]
        public string CheckPointID { get; set; }
        [Column("CHECK_POINT_CONTENT")]
        public string CheckPointContent { get; set; }
        [Column("HANDLER_COMMAND", TypeName = "VARCHAR2")]
        public string HandlerCommand { get; set; }
        [Column("MSG_DICT_CODE", TypeName = "VARCHAR2")]
        public string MsgDictCode { get; set; }
        [Column("MSG_DICT_MESSAGE", TypeName = "VARCHAR2")]
        public string MsgDictMessage { get; set; }
        [Column("DOCTYPE_ID", TypeName = "VARCHAR2")]
        public string DocTypeID { get; set; }
        [Column("DOCTYPE_NAME", TypeName = "VARCHAR2")]
        public string DocTypeName { get; set; }
        [Column("IS_VALID")]
        public int IsValid { get; set; }
        [Column("SCORE")]
        public float Score { get; set; }
        [Column("ORDER_VALUE")]
        public int OrderValue { get; set; }
        [Column("WRITTEN_PERIOD")]
        public string WrittenPeriod { get; set; }
        [Column("QA_EVENT_TYPE")]
        public string QaEventType { get; set; }
        [Column("EXPRESSION")]
        public string Expression { get; set; }
    }
}