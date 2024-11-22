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
        // lấy mô tả đối tượng database
        Entities db = new Entities();
        // hiển thị trang chủ
        public ActionResult Index()
        {
            // trả dữ liệu cây xuống viewBag trong điều kiện là trạng thái không bị khóa
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
            // trả dữ liệu cây xuống viewBag trong điều kiện là trạng thái không bị khóa
            ViewBag.Caycanh = db.Cays.Where((x) => x.Trangthai == true).ToList();
            return View();
        }

        // Trả về một id lấy từ get url vd: https://localhost:44372/Home/Details/3  cây có id = 3
        public ActionResult Details(int id)
        {
            // tìm 1 đối tượng trong db có id = với id lấy được, nếu không tìm được sẽ trả về null
            var item = db.Cays.Find(id);
            //  nếu item =  null chạy khối ì
            if (item == null)
            {
                // Có thể thêm thông tin debug nếu cần
                Console.WriteLine($"Không tìm thấy cây với ID: {id}");
            }
            // nếu item tồn tại, trả về view
            return View(item);
        }
        public ActionResult DangKy()
        {
            return View();
        }
        // su dung phuong thuc post
        [HttpPost]
        // lấy dữ liệu từ input form 
        public ActionResult DangKy(NguoiDung nguoiDung)
        {
            // them vao bang nguoi nguoi dung trong database 
            db.NguoiDungs.Add(nguoiDung);

            // Luu thông tin 
            db.SaveChanges();
            // chuyen ve trang dang nhap
            return RedirectToAction("DangNhap", "Home");
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        // Su dung phuong thuc post
        [HttpPost]
        // lấy dữ liệu từ form tra ve nguoiDung
        public ActionResult DangNhap(NguoiDung nguoiDung)
        {
            // đặt biến tài khoản và mật khẩu
            var taikhoan = nguoiDung.Email;
            var matkhau = nguoiDung.Matkhau;

            // kiểm  tài khoản có đúng hay không và kiểm tài khoản không bị khóa
            var checkLogin = db.NguoiDungs.FirstOrDefault(x => x.Email == taikhoan && x.Matkhau == matkhau && x.Trangthai == true);
           
            // nếu người dùng tồn tại chạy khối if
            if (checkLogin != null)
            {   // Kiểm tra vai trò người dùng nếu true trả về admin, nếu false trả về index như người dùng thông thường
                if(checkLogin.Vaitro == true)
                {
                    // Tạo một session User có dữ liệu cho phép duy trì đăng nhập
                    Session["User"] = checkLogin;
                    // trả về trang admin
                    return RedirectToAction("HomeAdmin", "Admin");
                }
                // Tạo một session User có dữ liệu cho phép duy trì đăng nhập
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
            // đặt session bằng null để đăng xuất
            Session["User"] = null;
            // Trả về trang chủ với view khách( chưa đăng nhập)
            return RedirectToAction("Index", "Home");
        }



    }
}