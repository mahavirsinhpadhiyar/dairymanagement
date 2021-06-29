using DairyManagement.Infrastructure;
using DairyManagement.Models;
using DairyManagement.Models.Entities;
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
                    EmployeeId = m.c.s.EmployeeId,
                    Id = m.c.s.Id
                }).ToList();

            return View(empToCustMilkVM);
        }

        public ActionResult Create(int? Id)
        {
            EmpToCustMilkVM empToCustMilkVM = new EmpToCustMilkVM() { Date = System.DateTime.Now };
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

            if (Id != 0 && Id != null)
            {
                var existingCustomerMilkDetail = db.StaffGivenMilkToCustomer.FirstOrDefault(c => c.Id == Id);

                if (existingCustomerMilkDetail == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    empToCustMilkVM.CustomerId = existingCustomerMilkDetail.CustomerId;
                    empToCustMilkVM.Date = existingCustomerMilkDetail.Date;
                    empToCustMilkVM.MilkGiven = existingCustomerMilkDetail.MilkGiven;
                    empToCustMilkVM.MilkType = existingCustomerMilkDetail.MilkType;
                    empToCustMilkVM.EmployeeId = existingCustomerMilkDetail.EmployeeId;
                    empToCustMilkVM.Id = existingCustomerMilkDetail.Id;
                }
            }

            return View(empToCustMilkVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpToCustMilkVM empToCustMilkVM)
        {
            if (ModelState.IsValid)
            {
                if (empToCustMilkVM.Id == 0)
                {
                    db.StaffGivenMilkToCustomer.Add(new StaffGivenMilkToCustomer()
                    {
                        CustomerId = empToCustMilkVM.CustomerId,
                        Date = empToCustMilkVM.Date,
                        EmployeeId = empToCustMilkVM.EmployeeId,
                        MilkGiven = empToCustMilkVM.MilkGiven,
                        MilkType = empToCustMilkVM.MilkType
                    });
                }
                else
                {
                    var existingCustomerMilkDetail = db.StaffGivenMilkToCustomer.FirstOrDefault(c => c.Id == empToCustMilkVM.Id);

                    if (existingCustomerMilkDetail == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        existingCustomerMilkDetail.CustomerId = empToCustMilkVM.CustomerId;
                        existingCustomerMilkDetail.Date = empToCustMilkVM.Date;
                        existingCustomerMilkDetail.MilkGiven = empToCustMilkVM.MilkGiven;
                        existingCustomerMilkDetail.MilkType = empToCustMilkVM.MilkType;
                        existingCustomerMilkDetail.EmployeeId = empToCustMilkVM.EmployeeId;
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empToCustMilkVM);
        }

        public ActionResult Delete(int? Id)
        {
          if (Id != 0)
            {
                var existingCustomerMilkDetail = db.StaffGivenMilkToCustomer.FirstOrDefault(c => c.Id == Id);

                if (existingCustomerMilkDetail == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    db.StaffGivenMilkToCustomer.Remove(existingCustomerMilkDetail);
                }

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}