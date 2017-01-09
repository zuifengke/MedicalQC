using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models
{

    public class SysRole
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SysRole()
        {
            //this.Place = string.Empty;
            //this.Name = string.Empty;
            //this.Tel = string.Empty;
            //this.Product = string.Empty;
            //this.SitePath = string.Empty;
        }
    }
}
