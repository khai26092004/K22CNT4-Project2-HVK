using K22CNT4_HVK_TTCD1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_HVK_TTCD1.Controllers
{
    public class HomeController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            ViewBag.Caycanh = db.Cays.Where((x) => x.Trangthai == true).ToList();
            

            return View();
        }

        public ActionResult TinTuc()
        {          
            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult Cay()
        {
            ViewBag.Caycanh = db.Cays.Where((x) => x.Trangthai == true).ToList();
            return View();
        }
        public ActionResult Details(int id)
        {
            var item = db.Cays.Find(id);
            if (item == null)
            {
                // Có thể thêm thông tin debug nếu cần
                Console.WriteLine($"Không tìm thấy cây với ID: {id}");
            }
            return View(item);
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(NguoiDung nguoiDung)
        {
            db.NguoiDungs.Add(nguoiDung);
            db.SaveChanges();
            return RedirectToAction("DangNhap", "Home");
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(NguoiDung nguoiDung)
        {
            var taikhoan = nguoiDung.Email;
            var matkhau = nguoiDung.Matkhau;

            var checkLogin = db.NguoiDungs.FirstOrDefault(x => x.Email == taikhoan && x.Matkhau == matkhau && x.Trangthai == true);
           
            // If the user exists, redirect to the Index page
            if (checkLogin != null)
            {
                if(checkLogin.Vaitro == true)
                {
                    Session["User"] = checkLogin;
                    return RedirectToAction("HomeAdmin", "Admin");
                }
                Session["User"] = checkLogin;
                return RedirectToAction("Index","Home");
            }
            else
            {
                // If the login fails, show an error message
                ViewBag.ErrorMessage = "Invalid email or password";
                return View(nguoiDung);
            }
        }
        public ActionResult DangXuat()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }



    }
}