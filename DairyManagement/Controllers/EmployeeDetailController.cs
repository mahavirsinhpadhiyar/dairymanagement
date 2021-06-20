using DairyManagement.Models;
using DairyManagement.Models.Entities;
using DairyManagement.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace DairyManagement.Controllers
{
    public class EmployeeDetailController : Controller
    {
        private DMDBContext db = new DMDBContext();
        // GET: EmployeeDetail
        public ActionResult Index(string Message)
        {
            List<EmployeeDetailsVM> empDetailsList = new List<EmployeeDetailsVM>();

            empDetailsList = db.EmployeeInfo
                .Select(m => new EmployeeDetailsVM()
                {
                    Address = m.Address,
                    EmployeeId = m.Id,
                    Name = m.Name,
                    Number = m.Number
                }).ToList();

            ViewBag.Message = Message;
            return View(empDetailsList);
        }

        public ActionResult Create()
        {
            EmployeeDetailsVM employeeDetailsVM = new EmployeeDetailsVM();
            return View(employeeDetailsVM);
        }

        [HttpPost]
        public ActionResult Create(EmployeeDetailsVM employeeDetailsVM)
        {
            try
            {
                EmployeeDetail emp = new EmployeeDetail();
                emp.Address = employeeDetailsVM.Address;
                emp.CreatedDate = DateTime.Now;
                emp.Number = employeeDetailsVM.Number;
                emp.Name = employeeDetailsVM.Name;

                db.EmployeeInfo.Add(emp);
                db.SaveChanges();

                var routeValues = new RouteValueDictionary { { "Message", "Success" } };
                return RedirectToAction("Index", "EmployeeDetail", routeValues);
            }
            catch (Exception ex)
            {
                var routeValues = new RouteValueDictionary { { "Message", "Error" } };
                return RedirectToAction("Index", "EmployeeDetail", routeValues);
            }
        }

        public ActionResult Edit(int Id)
        {
            EmployeeDetail emp = db.EmployeeInfo.Find(Id);
            EmployeeDetailsVM employeeDetailsVM = new EmployeeDetailsVM()
            {
                Address = emp.Address,
                EmployeeId = emp.Id,
                Name = emp.Name,
                Number = emp.Number
            };
            return View(employeeDetailsVM);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeDetailsVM employeeDetailsVM)
        {
            try
            {
                EmployeeDetail emp = db.EmployeeInfo.Find(employeeDetailsVM.EmployeeId);

                emp.Address = employeeDetailsVM.Address;
                emp.Number = employeeDetailsVM.Number;
                emp.Name = employeeDetailsVM.Name;
                emp.UpdatedBy = 1;
                emp.UpdatedDate = DateTime.Now;
                
                db.SaveChanges();

                var routeValues = new RouteValueDictionary { { "Message", "Success" } };
                return RedirectToAction("Index", "EmployeeDetail", routeValues);
            }
            catch (Exception ex)
            {
                var routeValues = new RouteValueDictionary { { "Message", "Error" } };
                return RedirectToAction("Index", "EmployeeDetail", routeValues);
            }
        }

        // GET: VendorInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeInfo.Find(id);
            EmployeeDetailsVM employeeDetailsVM = new EmployeeDetailsVM();
            employeeDetailsVM.Address = employeeDetail.Address;
            employeeDetailsVM.EmployeeId = employeeDetail.Id;
            employeeDetailsVM.Name = employeeDetail.Name;
            employeeDetailsVM.Number = employeeDetail.Number;
            employeeDetailsVM.CreatedDate = employeeDetail.CreatedDate;
            employeeDetailsVM.UpdatedDate = employeeDetail.UpdatedDate;
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetailsVM);
        }

        // POST: VendorInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDetail employeeDetail = db.EmployeeInfo.Find(id);
            db.EmployeeInfo.Remove(employeeDetail);
            db.SaveChanges();
            var routeValues = new RouteValueDictionary { { "Message", "Success" } };
            return RedirectToAction("Index", "EmployeeDetail", routeValues);
        }
    }
}