using DairyManagement.Models;
using DairyManagement.Models.Entities;
using DairyManagement.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace DairyManagement.Controllers
{
    public class CustomerController : Controller
    {
        private DMDBContext db = new DMDBContext();
        // GET: CustomerDetail
        public ActionResult Index(string Message)
        {
            List<CustomerViewModel> customerDetailsList = new List<CustomerViewModel>();

            customerDetailsList = db.CustomerInfo
                .Select(m => new CustomerViewModel()
                {
                    CustomerAddress = m.CustomerAddress,
                    CustomerId = m.Id,
                    CustomerName = m.CustomerName,
                    CustomerPhoneNumber = m.CustomerPhoneNumber
                }).ToList();

            ViewBag.Message = Message;
            return View(customerDetailsList);
        }

        public ActionResult Create()
        {
            CustomerViewModel customerDetailsVM = new CustomerViewModel();
            return View(customerDetailsVM);
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel customerDetailsVM)
        {
            try
            {
                CustomerInfo customer = new CustomerInfo();
                customer.CustomerAddress = customerDetailsVM.CustomerAddress;
                customer.CreatedDate = DateTime.Now;
                customer.UpdatedDate = DateTime.Now;
                customer.CustomerPhoneNumber = customerDetailsVM.CustomerPhoneNumber;
                customer.CustomerName = customerDetailsVM.CustomerName;
                customer.CreatedBy = 1;

                db.CustomerInfo.Add(customer);
                db.SaveChanges();

                var routeValues = new RouteValueDictionary { { "Message", "Success" } };
                return RedirectToAction("Index", "Customer", routeValues);
            }
            catch (Exception ex)
            {
                var routeValues = new RouteValueDictionary { { "Message", "Error" } };
                return RedirectToAction("Index", "Customer", routeValues);
            }
        }

        public ActionResult Edit(int Id)
        {
            CustomerInfo customer = db.CustomerInfo.Find(Id);
            CustomerViewModel customerDetailsVM = new CustomerViewModel()
            {
                CustomerAddress = customer.CustomerAddress,
                CustomerId = customer.Id,
                CustomerName = customer.CustomerName,
                CustomerPhoneNumber = customer.CustomerPhoneNumber
            };
            return View(customerDetailsVM);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerDetailsVM)
        {
            try
            {
                CustomerInfo emp = db.CustomerInfo.Find(customerDetailsVM.CustomerId);

                emp.CustomerAddress = customerDetailsVM.CustomerAddress;
                emp.CustomerPhoneNumber = customerDetailsVM.CustomerPhoneNumber;
                emp.CustomerName = customerDetailsVM.CustomerName;
                emp.UpdateBy = 1;
                emp.UpdatedDate = DateTime.Now;

                db.SaveChanges();

                var routeValues = new RouteValueDictionary { { "Message", "Success" } };
                return RedirectToAction("Index", "Customer", routeValues);
            }
            catch (Exception ex)
            {
                var routeValues = new RouteValueDictionary { { "Message", "Error" } };
                return RedirectToAction("Index", "Customer", routeValues);
            }
        }

        // GET: VendorInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customer = db.CustomerInfo.Find(id);
            CustomerViewModel customerDetailsVM = new CustomerViewModel();
            customerDetailsVM.CustomerAddress = customer.CustomerAddress;
            customerDetailsVM.CustomerId = customer.Id;
            customerDetailsVM.CustomerName = customer.CustomerName;
            customerDetailsVM.CustomerPhoneNumber = customer.CustomerPhoneNumber;
            customerDetailsVM.CreatedDate = customer.CreatedDate;
            customerDetailsVM.UpdatedDate = customer.UpdatedDate;
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customerDetailsVM);
        }

        // POST: VendorInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerInfo customerDetail = db.CustomerInfo.Find(id);
            db.CustomerInfo.Remove(customerDetail);
            db.SaveChanges();
            var routeValues = new RouteValueDictionary { { "Message", "Success" } };
            return RedirectToAction("Index", "Customer", routeValues);
        }
    }
}