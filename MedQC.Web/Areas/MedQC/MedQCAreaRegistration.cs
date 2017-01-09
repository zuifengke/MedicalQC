using System.Web.Mvc;

namespace MedQC.Web.Areas.MedQC
{
    public class MedQCAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MedQC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MedQC_default",
                "MedQC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
