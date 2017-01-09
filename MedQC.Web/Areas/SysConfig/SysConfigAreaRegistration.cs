using System.Web.Mvc;

namespace MedQC.Web.Areas.SysConfig
{
    public class SysConfigAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SysConfig";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SysConfig_default",
                "SysConfig/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
