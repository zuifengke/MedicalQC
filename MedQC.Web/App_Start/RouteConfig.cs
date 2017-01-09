using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MedQC.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("HtmlDefault", "{controller}/{action}/{id}.htm"
                , new { controller = "Home", action = "Index"
                }
                , new string[] { "MedQC.Web.Controllers" });

            routes.MapRoute("HtmlDefault2", "{controller}/{action}.htm"
                , new
                {
                    controller = "Home",
                    action = "Index"
                }
                , new string[] { "MedQC.Web.Controllers" });

          

            routes.MapRoute(
                "Default", // 路由名称  
                "{controller}/{action}/{id}", // 带有参数的 URL  
                new {  action = "Index", id = UrlParameter.Optional } 
                , new string[] { "MedQC.Web.Controllers" }
            );
        }
    }
}