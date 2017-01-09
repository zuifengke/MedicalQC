using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models
{

    public class SysLog
    {
        public string Thread { get; set; }
        public string LogLevel { get; set; }
        public string Logger { get; set; }
        public DateTime LogDate { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }

    }
}
