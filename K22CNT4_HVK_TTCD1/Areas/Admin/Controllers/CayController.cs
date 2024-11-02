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
    public class CayController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/Cay
        public ActionResult Index()
        {

            var user = Session["User"] as K22CNT4_HVK_TTCD1.Models.NguoiDung;
            if(user != null)
            {
                var cays = db.Cays.Include(c => c.DanhMucCay);
                return View(cays.ToList());
            }else
            {
                return RedirectToAction("DangNhap","Home", new { area = "" });
            }
        }

        // GET: Admin/Cay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cay cay = db.Cays.Find(id);
            if (cay == null)
            {
                return HttpNotFound();
            }
            return View(cay);
        }

        // GET: Admin/Cay/Create
        public ActionResult Create()
        {
            ViewBag.Iddanhmuc = new SelectList(db.DanhMucCays, "Id", "Tendanhmuc");
            return View();
        }

        // POST: Admin/Cay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tencay,Iddanhmuc,Soluong,Dongia,Hinhanh,Trangthai")] Cay cay)
        {
            if (ModelState.IsValid)
            {
                db.Cays.Add(cay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Iddanhmuc = new SelectList(db.DanhMucCays, "Id", "Tendanhmuc", cay.Iddanhmuc);
            return View(cay);
        }

        // GET: Admin/Cay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cay cay = db.Cays.Find(id);
            if (cay == null)
            {
                return HttpNotFound();
            }
            ViewBag.Iddanhmuc = new SelectList(db.DanhMucCays, "Id", "Tendanhmuc", cay.Iddanhmuc);
            return View(cay);
        }

        // POST: Admin/Cay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tencay,Iddanhmuc,Soluong,Dongia,Hinhanh,Trangthai")] Cay cay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Iddanhmuc = new SelectList(db.DanhMucCays, "Id", "Tendanhmuc", cay.Iddanhmuc);
            return View(cay);
        }

        // GET: Admin/Cay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cay cay = db.Cays.Find(id);
            if (cay == null)
            {
                return HttpNotFound();
            }
            return View(cay);
        }

        // POST: Admin/Cay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cay cay = db.Cays.Find(id);
            db.Cays.Remove(cay);
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
