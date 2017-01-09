using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models
{

    public class SysUser
    {
        public int ID { get; set; }
        public string LoginName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Tel { get; set; }
        public string RoleIDs { get; set; }
        public string RoleNames { get; set; }

        public SysUser()
        {
            //this.Place = string.Empty;
            //this.Name = string.Empty;
            //this.Tel = string.Empty;
            //this.Product = string.Empty;
            //this.SitePath = string.Empty;
        }
    }
}
