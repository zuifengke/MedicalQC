using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models
{
    /// <summary>
    /// 系统参数
    /// </summary>
    public class SysParameter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ParentID { get; set; }
        public string ParentName { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public SysParameter()
        {
            //this.Place = string.Empty;
            //this.Name = string.Empty;
            //this.Tel = string.Empty;
            //this.Product = string.Empty;
            //this.SitePath = string.Empty;
        }
    }
}
