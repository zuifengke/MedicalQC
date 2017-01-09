using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models
{

    public class SysMenu
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public int ParentID { get; set; }
        public string ParentName { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string MenuType { get; set; }

        public SysMenu()
        {
            //this.Place = string.Empty;
            //this.Name = string.Empty;
            //this.Tel = string.Empty;
            //this.Product = string.Empty;
            //this.SitePath = string.Empty;
        }
    }
}
