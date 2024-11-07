using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT4_HVK_TTCD1.Models;

namespace K22CNT4_HVK_TTCD1.Areas.Admin.Controllers
{
    public class DanhMucCayController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/DanhMucCay
        public ActionResult Index()
        {
            var user = Session["User"] as K22CNT4_HVK_TTCD1.Models.NguoiDung;
            if (user != null)
            {
                return View(db.DanhMucCays.ToList());
            }
            else
            {
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
        }

        // GET: Admin/DanhMucCay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCay danhMucCay = db.DanhMucCays.Find(id);
            if (danhMucCay == null)
            {
                return HttpNotFound();
            }
            return View(danhMucCay);
        }

        // GET: Admin/DanhMucCay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucCay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tendanhmuc,Trangthai")] DanhMucCay danhMucCay)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucCays.Add(danhMucCay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhMucCay);
        }

        // GET: Admin/DanhMucCay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCay danhMucCay = db.DanhMucCays.Find(id);
            if (danhMucCay == null)
            {
                return HttpNotFound();
            }
            return View(danhMucCay);
        }

        // POST: Admin/DanhMucCay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tendanhmuc,Trangthai")] DanhMucCay danhMucCay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMucCay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMucCay);
        }

        // GET: Admin/DanhMucCay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCay danhMucCay = db.DanhMucCays.Find(id);
            if (danhMucCay == null)
            {
                return HttpNotFound();
            }
            return View(danhMucCay);
        }

        // POST: Admin/DanhMucCay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMucCay danhMucCay = db.DanhMucCays.Find(id);
            db.DanhMucCays.Remove(danhMucCay);
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
