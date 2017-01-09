using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MedQC.Web.Filters
{
    public class MyExceptionAttribute : FilterAttribute, IExceptionFilter
    {

        public void OnException(ExceptionContext filterContext)
        {

            if (!filterContext.ExceptionHandled ||
                filterContext.Exception is NullReferenceException)
            {
                GlobalMethod.log.Error(filterContext.HttpContext.Request.Url,filterContext.Exception);
                //GlobalMethod.log.Info("");
                //GlobalMethod.log.Debug("");
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new ContentResult() { Content ="系统发生错误了;"+ filterContext.Exception.Message };
                }
                else
                    filterContext.Result = new RedirectResult("/error.html");
                
                filterContext.ExceptionHandled = true;
            }
        }
    }
}