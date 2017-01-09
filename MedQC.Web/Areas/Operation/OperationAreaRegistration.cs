using System.Web.Mvc;

namespace MedQC.Web.Areas.Operation
{
    public class OperationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Operation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Operation_default",
                "Operation/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
