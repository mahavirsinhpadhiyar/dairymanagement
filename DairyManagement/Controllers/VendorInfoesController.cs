using DairyManagement.Infrastructure;
using DairyManagement.Models.LiveDBEDMX;
using DairyManagement.ViewModels.Vendor;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DairyManagement.Controllers
{
    [CustomAuthorize]
    public class VendorInfoesController : HandleExceptionController
    {
        private dairymanagementEntities db = new dairymanagementEntities();

        // GET: VendorInfoes
        public ActionResult Index()
        {
            List<VendorListViewModel> vendorList = db.VendorInfoes.ToList().Select(m => new VendorListViewModel()
            {
                Id = m.Id,
                CreatedBy = db.UserInfoes.FirstOrDefault(q => q.Id == m.CreatedBy)?.FirstName,
                UpdateBy = db.UserInfoes.FirstOrDefault(q => q.Id == m.UpdateBy)?.FirstName,
                CreatedDate = m.CreatedDate,
                LocationName = m.LocationName,
                VendorName = m.VendorName,
                UpdatedDate = m.UpdatedDate
            }).ToList();
            return View(vendorList.ToList());
        }

        // GET: VendorInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorInfo vendorInfo = db.VendorInfoes.Find(id);
            VendorViewModel vendorModel = new VendorViewModel();
            vendorModel.VendorName = vendorInfo.VendorName;
            vendorModel.LocationName = vendorInfo.LocationName;
            vendorModel.Id = vendorInfo.Id;
            vendorModel.CreatedBy = vendorInfo.UserInfo?.FirstName;
            vendorModel.UpdateBy = vendorInfo.UserInfo1?.FirstName;
            vendorModel.CreatedDate = vendorInfo.CreatedDate;
            vendorModel.UpdatedDate = vendorInfo.UpdatedDate;
            if (vendorInfo == null)
            {
                return HttpNotFound();
            }
            return View(vendorModel);
        }

        // GET: VendorInfoes/Create
        public ActionResult Create()
        {
            return View(new VendorViewModel());
        }

        // POST: VendorInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendorViewModel vendorInfo)
        {
            if (ModelState.IsValid)
            {
                db.VendorInfoes.Add(new VendorInfo()
                {
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    VendorName = vendorInfo.VendorName,
                    LocationName = vendorInfo.LocationName,
                    UpdatedDate = null
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendorInfo);
        }

        // GET: VendorInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorInfo vendorInfo = db.VendorInfoes.Find(id);
            VendorViewModel vendorModel = new VendorViewModel();
            vendorModel.VendorName = vendorInfo.VendorName;
            vendorModel.LocationName = vendorInfo.LocationName;
            vendorModel.Id = vendorInfo.Id;
            if (vendorInfo == null)
            {
                return HttpNotFound();
            }
            return View(vendorModel);
        }

        // POST: VendorInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendorViewModel vendorViewModel)
        {
            if (ModelState.IsValid)
            {
                VendorInfo vendorModel = db.VendorInfoes.Find(vendorViewModel.Id);

                vendorModel.VendorName = vendorViewModel.VendorName;
                vendorModel.LocationName = vendorViewModel.LocationName;
                vendorModel.UpdateBy = 1;
                vendorModel.UpdatedDate = System.DateTime.Now;

                db.Entry(vendorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendorViewModel);
        }

        // GET: VendorInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorInfo vendorInfo = db.VendorInfoes.Find(id);
            VendorViewModel vendorModel = new VendorViewModel();
            vendorModel.VendorName = vendorInfo.VendorName;
            vendorModel.LocationName = vendorInfo.LocationName;
            vendorModel.Id = vendorInfo.Id;
            vendorModel.CreatedBy = vendorInfo.UserInfo?.FirstName;
            vendorModel.UpdateBy = vendorInfo.UserInfo1?.FirstName;
            vendorModel.CreatedDate = vendorInfo.CreatedDate;
            vendorModel.UpdatedDate = vendorInfo.UpdatedDate;
            if (vendorInfo == null)
            {
                return HttpNotFound();
            }
            return View(vendorModel);
        }

        // POST: VendorInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorInfo vendorInfo = db.VendorInfoes.Find(id);
            db.VendorInfoes.Remove(vendorInfo);
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
