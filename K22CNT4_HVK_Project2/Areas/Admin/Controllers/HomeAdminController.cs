using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_HVK_TTCD1.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            // Tạo một biến chữa session kiểm tra người dùng
            var user = Session["User"] as K22CNT4_HVK_TTCD1.Models.NguoiDung;

            if (user != null && user.Vaitro == true)
            {
                return View();
            }
            else
            {
                // Nếu người dùng null trả về đăng nhập
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
        }
    }
}