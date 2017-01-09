using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedQC.Web.Filters
{
    public class MyOutputCacheAttribute : OutputCacheAttribute
    {
        public MyOutputCacheAttribute()
        {
#if DEBUG
            this.Duration = int.Parse(ConfigurationManager.AppSettings["cache.page.time.debug"]);

#else
            this.Duration = int.Parse(ConfigurationManager.AppSettings["cache.page.time"]);
#endif
        }
    }
}