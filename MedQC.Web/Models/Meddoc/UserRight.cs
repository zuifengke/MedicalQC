using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedQC.Web.Models.Meddoc
{

    public class UserRight
    {
        public string UserID { get; set; }
        public string UserPwd { get; set; }
        ///// <summary>
        ///// 联系方式
        ///// </summary>
        //public string Tel { get; set; }
        ///// <summary>
        ///// 寄卖物品
        ///// </summary>
        //public string Product { get; set; }
        ///// <summary>
        ///// 价格
        ///// </summary>
        //public float Price { get; set; }
        ///// <summary>
        ///// 提交时间
        ///// </summary>
        //public DateTime SubTime { get; set; }
        ///// <summary>
        ///// 所在分区
        ///// </summary>
        //public string Place { get; set; }
        ///// <summary>
        ///// 数据来源站点域名
        ///// </summary>
        //public string SitePath { get; set; }

        public UserRight()
        {
            //this.Place = string.Empty;
            //this.Name = string.Empty;
            //this.Tel = string.Empty;
            //this.Product = string.Empty;
            //this.SitePath = string.Empty;
        }
    }
}
