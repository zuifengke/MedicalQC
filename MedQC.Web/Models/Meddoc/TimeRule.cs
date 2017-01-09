using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models.Meddoc
{
    [Table("TIME_RULE_T")]
    public class TimeRule
    {
        [Key]
        [Column("RULE_ID")]
        public string RuleID { get; set; }
        [Column("DOCTYPE_NAME",TypeName = "VARCHAR2")]
        public string DocTypeName { get; set; }

    }
}