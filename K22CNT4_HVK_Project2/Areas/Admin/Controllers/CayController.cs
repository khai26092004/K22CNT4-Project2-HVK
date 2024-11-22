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
    /// <summary>
    ///  ĐƯợc tạo ra bới ASP.NET render controller Using entityFramework
    /// </summary>
    public class CayController : Controller
    {
        // lấy mô tả đối tượng database
        private Entities db = new Entities();

        // GET: Admin/Cay
        public ActionResult Index()
        {
            // Gán user bằng session
            var user = Session["User"] as K22CNT4_HVK_TTCD1.Models.NguoiDung;
            // kiểm tra user nếu đúng thì hiển thị danh sách cây
            if (user != null && user.Vaitro == true)
            {
                var cays = db.Cays.Include(c => c.DanhMucCay);
                return View(cays.ToList());
            }else
            {
                // sai, trả về trang đăng nhập
                return RedirectToAction("DangNhap","Home", new { area = "" });
            }
        }

        // GET: Admin/Cay/Details/5
        // Trả về một id lấy từ get form cây có  vidu: id = 5
        public ActionResult Details(int? id)
        {
           // nếu k tìm thấy báo lỗi ra trình duyệt
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // tạo một đôi tượng cây tìm kiếm được theo id tồn tại trong db
            Cay cay = db.Cays.Find(id);
            // Nếu cay rỗng chạy if và trả về lỗi
            if (cay == null)
            {
                return HttpNotFound();
            }
            // Trả về cay nếu các cậu lệnh điều kiện không thỏa mãn
            return View(cay);
        }

        // GET: Admin/Cay/Create
        public ActionResult Create()
        {
            // Hiển thị teend dannh mục tra xuống viewu bag dưới dạng SelectList
            ViewBag.Iddanhmuc = new SelectList(db.DanhMucCays, "Id", "Tendanhmuc");
            return View();
        }

        // POST: Admin/Cay/Create
        // SỬ dụng phuonmgw thức post
        [HttpPost]
        // Sử dụng kiểm tra giá trị
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tencay,Iddanhmuc,Soluong,Dongia,Hinhanh,Trangthai")] Cay cay)
        {
            // Nếu kiểm tra đúng tra về ModelState đúng và cho phép thêm cây mới
            if (ModelState.IsValid)
            {
                // Thêm cây vào db
                db.Cays.Add(cay);
                // Lưu thay đổi
                db.SaveChanges();
                // Trả về trang hiển thị
                return RedirectToAction("Index");
            }
            // Nếu điều kiện trên k thỏa mãn trả về lại viewBag 1 lần nữa
            ViewBag.Iddanhmuc = new SelectList(db.DanhMucCays, "Id", "Tendanhmuc", cay.Iddanhmuc);
            // Trả về giá trị vừa được nhập vào form trong trường hợp lỗi 
            return View(cay);
        }

        // GET: Admin/Cay/Edit/5
        // Trả về một id lấy từ get form cây có  vidu: id = 5
        public ActionResult Edit(int? id)
        {
            // kiểm tra id nếu null trả về BadRequest 505
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // tạo một đôi tượng cây tìm kiếm được theo id tồn tại trong db
            Cay cay = db.Cays.Find(id);
            // Nếu cay rỗng chạy if và trả về notfound
            if (cay == null)
            {
                return HttpNotFound();
            }
            // Nếu điều kiện trên k thỏa mãn trả về lại viewBag 1 lần nữa
            ViewBag.Iddanhmuc = new SelectList(db.DanhMucCays, "Id", "Tendanhmuc", cay.Iddanhmuc);
            // Trả về giá trị vừa được nhập vào form trong trường hợp lỗi 
            return View(cay);
        }

        // POST: Admin/Cay/Edit/5

        // SỬ dụng phuonmgw thức post
        [HttpPost]
        // Sử dụng kiểm tra giá trị
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tencay,Iddanhmuc,Soluong,Dongia,Hinhanh,Trangthai")] Cay cay)
        {
            // Nếu kiểm tra đúng tra về ModelState đúng và cho sửa thêm cây mới
            if (ModelState.IsValid)
            {
                db.Entry(cay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Nếu điều kiện trên k thỏa mãn trả về lại viewBag 1 lần nữa
            ViewBag.Iddanhmuc = new SelectList(db.DanhMucCays, "Id", "Tendanhmuc", cay.Iddanhmuc);
            // Trả về giá trị vừa được nhập vào form trong trường hợp lỗi 
            return View(cay);
        }

        // GET: Admin/Cay/Delete/5
        // Lấy id từ get
        public ActionResult Delete(int? id)
        {
            // kiểm tra nếu id rỗng trả về BadRequest
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // tạo một đối tượng cây lấy từ database
            Cay cay = db.Cays.Find(id);
            // Kiểm tra nếu cay rỗng trả về HttpNotFound
            if (cay == null)
            {
                return HttpNotFound();
            }
            // Nếu k tra về giá trị trước đó
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
