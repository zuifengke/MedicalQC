using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web.Areas.Operation.Models
{
    public class Parameter
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }
    }
}