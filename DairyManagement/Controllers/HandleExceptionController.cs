using System.Web.Mvc;

namespace DairyManagement.Controllers
{
    public class HandleExceptionController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            var result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };

            result.ViewBag.ErrorMessage = filterContext.Exception.InnerException != null ? filterContext.Exception.InnerException.InnerException.Message : filterContext.Exception.Message;
            filterContext.Result = result;
            filterContext.ExceptionHandled = true;
        }
    }
}