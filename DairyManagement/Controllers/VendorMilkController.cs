using DairyManagement.Infrastructure;
using DairyManagement.Models.LiveDBEDMX;
using DairyManagement.ViewModels.VendorMilk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DairyManagement.Controllers
{
    [CustomAuthorize]
    public class VendorMilkController : HandleExceptionController
    {
        private dairymanagementEntities db = new dairymanagementEntities();

        // GET: VendorMilk
        public ActionResult Index()
        {
            List<VendorMilkViewModel> vendorList = db.VendorMilkInfoes.ToList().Select(m => new VendorMilkViewModel()
            {
                Id = m.Id,
                CreatedBy = db.UserInfoes.FirstOrDefault(q => q.Id == m.CreatedBy)?.FirstName,
                UpdateBy = db.UserInfoes.FirstOrDefault(q => q.Id == m.UpdatedBy)?.FirstName,
                CreatedDate = m.CreatedDate,
                UpdatedDate = m.UpdatedDate,
                FatValue = m.FatValue,
                MilkTypeId = m.MilkTypeId,
                MilkValue = m.MilkValue,
                Price = m.Price,
                Total = m.Total,
                VendorName = m.VendorInfo.VendorName,
                MilkType = m.MilkType.MilkType1
            }).ToList();
            return View(vendorList.ToList());
        }

        // GET: VendorMilk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorMilkInfo vendorMilk = db.VendorMilkInfoes.Find(id);
            if (vendorMilk == null)
            {
                return HttpNotFound();
            }
            VendorMilkViewModel vendorMilkViewModel = new VendorMilkViewModel();
            vendorMilkViewModel.Id = vendorMilk.Id;
            vendorMilkViewModel.FatValue = vendorMilk.FatValue;
            vendorMilkViewModel.MilkType = vendorMilk.MilkType.MilkType1;
            vendorMilkViewModel.MilkValue = vendorMilk.MilkValue;
            vendorMilkViewModel.Price = vendorMilk.Price;
            vendorMilkViewModel.Total = vendorMilk.Total;
            vendorMilkViewModel.CreatedBy = db.UserInfoes.FirstOrDefault(q => q.Id == vendorMilk.CreatedBy)?.FirstName;
            vendorMilkViewModel.UpdateBy = db.UserInfoes.FirstOrDefault(q => q.Id == vendorMilk.UpdatedBy)?.FirstName;
            vendorMilkViewModel.CreatedDate = vendorMilk.CreatedDate;
            vendorMilkViewModel.UpdatedDate = vendorMilk.UpdatedDate;
            vendorMilkViewModel.VendorName = vendorMilk.VendorInfo.VendorName;

            return View(vendorMilkViewModel);
        }

        // GET: VendorMilk/Create
        public ActionResult Create()
        {
            VendorMilkViewModel vendorMilkViewModel = new VendorMilkViewModel();
            vendorMilkViewModel.MilkTypeList = db.MilkTypes.ToList().Select(m => new SelectListItem()
            {
                Text = m.MilkType1,
                Value = m.Id.ToString()
            }).ToList();
            vendorMilkViewModel.VendorList = db.VendorInfoes.ToList().Select(m => new SelectListItem()
            {
                Text = m.VendorName,
                Value = m.Id.ToString()
            }).ToList();
            vendorMilkViewModel.Price = 28;
            return View(vendorMilkViewModel);
        }

        // POST: VendorMilk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendorMilkViewModel vendorMilkViewModel)
        {
            if (ModelState.IsValid)
            {
                db.VendorMilkInfoes.Add(new VendorMilkInfo()
                {
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    FatValue = vendorMilkViewModel.FatValue,
                    MilkTypeId = vendorMilkViewModel.MilkTypeId,
                    MilkValue = vendorMilkViewModel.MilkValue,
                    Price = vendorMilkViewModel.Price,
                    Total = vendorMilkViewModel.Total,
                    VendorId = vendorMilkViewModel.VendorId
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            vendorMilkViewModel.MilkTypeList = db.MilkTypes.ToList().Select(m => new SelectListItem()
            {
                Text = m.MilkType1,
                Value = m.Id.ToString()
            }).ToList();
            vendorMilkViewModel.VendorList = db.VendorInfoes.ToList().Select(m => new SelectListItem()
            {
                Text = m.VendorName,
                Value = m.Id.ToString()
            }).ToList();
            return View(vendorMilkViewModel);
        }

        // GET: VendorMilk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorMilkInfo vendorMilk = db.VendorMilkInfoes.Find(id);
            if (vendorMilk == null)
            {
                return HttpNotFound();
            }

            VendorMilkViewModel vendorMilkViewModel = new VendorMilkViewModel();
            vendorMilkViewModel.Id = vendorMilk.Id;
            vendorMilkViewModel.VendorId = vendorMilk.VendorId;
            vendorMilkViewModel.FatValue = vendorMilk.FatValue;
            vendorMilkViewModel.MilkTypeId = vendorMilk.MilkTypeId;
            vendorMilkViewModel.MilkValue = vendorMilk.MilkValue;
            vendorMilkViewModel.Price = vendorMilk.Price;
            vendorMilkViewModel.Total = vendorMilk.Total;
            vendorMilkViewModel.CreatedBy = db.UserInfoes.FirstOrDefault(q => q.Id == vendorMilk.CreatedBy)?.FirstName;
            vendorMilkViewModel.UpdateBy = db.UserInfoes.FirstOrDefault(q => q.Id == vendorMilk.UpdatedBy)?.FirstName;
            vendorMilkViewModel.CreatedDate = vendorMilk.CreatedDate;
            vendorMilkViewModel.UpdatedDate = vendorMilk.UpdatedDate;
            vendorMilkViewModel.MilkTypeList = db.MilkTypes.ToList().Select(m => new SelectListItem()
            {
                Text = m.MilkType1,
                Value = m.Id.ToString()
            }).ToList();
            vendorMilkViewModel.VendorList = db.VendorInfoes.ToList().Select(m => new SelectListItem()
            {
                Text = m.VendorName,
                Value = m.Id.ToString()
            }).ToList();

            return View(vendorMilkViewModel);
        }

        // POST: VendorMilk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendorMilkViewModel vendorMilkViewModel)
        {
            if (ModelState.IsValid)
            {
                VendorMilkInfo vendorMilk = db.VendorMilkInfoes.Find(vendorMilkViewModel.Id);
                if (vendorMilk == null)
                {
                    return HttpNotFound();
                }

                vendorMilk.VendorId = vendorMilkViewModel.VendorId;
                vendorMilk.FatValue = vendorMilkViewModel.FatValue;
                vendorMilk.MilkTypeId = vendorMilkViewModel.MilkTypeId;
                vendorMilk.MilkValue = vendorMilkViewModel.MilkValue;
                vendorMilk.Price = vendorMilkViewModel.Price;
                vendorMilk.Total = vendorMilkViewModel.Total;
                vendorMilk.UpdatedDate = DateTime.Now;
                vendorMilk.UpdatedBy = 1;

                db.Entry(vendorMilk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vendorMilkViewModel.MilkTypeList = db.MilkTypes.ToList().Select(m => new SelectListItem()
            {
                Text = m.MilkType1,
                Value = m.Id.ToString()
            }).ToList();
            vendorMilkViewModel.VendorList = db.VendorInfoes.ToList().Select(m => new SelectListItem()
            {
                Text = m.VendorName,
                Value = m.Id.ToString()
            }).ToList();
            return View(vendorMilkViewModel);
        }

        // GET: VendorMilk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorMilkInfo vendorMilk = db.VendorMilkInfoes.Find(id);

            VendorMilkViewModel vendorMilkViewModel = new VendorMilkViewModel();
            vendorMilkViewModel.Id = vendorMilk.Id;
            vendorMilkViewModel.VendorId = vendorMilk.VendorId;
            vendorMilkViewModel.FatValue = vendorMilk.FatValue;
            vendorMilkViewModel.MilkType = vendorMilk.MilkType.MilkType1;
            vendorMilkViewModel.MilkValue = vendorMilk.MilkValue;
            vendorMilkViewModel.Price = vendorMilk.Price;
            vendorMilkViewModel.Total = vendorMilk.Total;
            vendorMilkViewModel.VendorName = vendorMilk.VendorInfo.VendorName;
            vendorMilkViewModel.CreatedBy = db.UserInfoes.FirstOrDefault(q => q.Id == vendorMilk.CreatedBy)?.FirstName;
            vendorMilkViewModel.UpdateBy = db.UserInfoes.FirstOrDefault(q => q.Id == vendorMilk.UpdatedBy)?.FirstName;
            vendorMilkViewModel.UpdatedDate = vendorMilk.UpdatedDate;
            vendorMilkViewModel.CreatedDate = vendorMilk.CreatedDate;

            if (vendorMilk == null)
            {
                return HttpNotFound();
            }
            return View(vendorMilkViewModel);
        }

        // POST: VendorMilk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorMilkInfo vendorMilk = db.VendorMilkInfoes.Find(id);
            db.VendorMilkInfoes.Remove(vendorMilk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
