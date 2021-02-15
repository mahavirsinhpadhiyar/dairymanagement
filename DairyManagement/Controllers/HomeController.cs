using DairyManagement.Infrastructure;
using System.Web.Mvc;

namespace DairyManagement.Controllers
{
    [CustomAuthorize]
    public class HomeController : HandleExceptionController
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Index2()
        {
            return View("Index2");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult partialAddRow(int? i)
        {
            ViewBag.i = i;
            return PartialView();
        }
    }
}