using System.Web.Mvc;

namespace MedQC.Web.Areas.QC
{
    public class QCAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "QC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "QC_default",
                "QC/{controller}/{action}/{id}",
                new { controller= "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
