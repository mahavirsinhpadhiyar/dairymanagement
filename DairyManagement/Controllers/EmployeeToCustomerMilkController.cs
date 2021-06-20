using DairyManagement.Infrastructure;
using DairyManagement.Models;
using DairyManagement.ViewModels.EmployeeToCustomerMilk;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace DairyManagement.Controllers
{
    [CustomAuthorize]
    public class EmployeeToCustomerMilkController : Controller
    {
        private DMDBContext db = new DMDBContext();
        // GET: EmployeeToCustomerMilk
        public ActionResult Index(string Message)
        {
            List<EmpToCustMilkVM> empToCustMilkVM = new List<EmpToCustMilkVM>();

            empToCustMilkVM = db.StaffGivenMilkToCustomer
                .Join(db.EmployeeInfo, s => s.EmployeeId, e => e.Id, (s, e) => new { s, e })
                .Join(db.CustomerInfo, c => c.s.CustomerId, ci => ci.Id, (c, ci) => new { c, ci })
                .Select(m => new EmpToCustMilkVM()
                {
                    CustomerId = m.c.s.CustomerId,
                    CustomerName = m.ci.CustomerName,
                    Date = m.c.s.Date,
                    EmployeeName = m.c.e.Name,
                    MilkGiven = m.c.s.MilkGiven,
                    MilkType = m.c.s.MilkType,
                    EmployeeId = m.c.s.EmployeeId
                }).ToList();

            return View(empToCustMilkVM);
        }

        public ActionResult Create()
        {
            EmpToCustMilkVM empToCustMilkVM = new EmpToCustMilkVM();
            empToCustMilkVM.CustomerInfoList = db.CustomerInfo.ToList().Select(m => new SelectListItem()
            {
                Text = m.CustomerName,
                Value = m.Id.ToString()
            }).ToList();
            empToCustMilkVM.EmployeeInfoList = db.EmployeeInfo.ToList().Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Id.ToString()
            }).ToList();

            return View(empToCustMilkVM);
        }
    }
}