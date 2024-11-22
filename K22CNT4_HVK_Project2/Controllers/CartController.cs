using K22CNT4_HVK_TTCD1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22CNT4_HVK_TTCD1.Controllers
{
    public class CartController : Controller
    {
        // lấy mô tả đối tượng database
        Entities db = new Entities();
        // GET: Cart
        public ActionResult Index()
        {
            // tạo biến user với session có kiểu là class người dùng trong model
            var user = Session["User"] as K22CNT4_HVK_TTCD1.Models.NguoiDung;

            // lấy sản phẩm theo id của người dùng được lấy từ session
            var cartItems = db.GioHangs.Where(g => g.Idnguoidung == user.Id).ToList();
            // Kiểm tra tổng số lượng 
            int cartItemCount = cartItems.Sum(item => item.soluong);
            // Cập nhật lại số lượng sản phẩm trong giỏ hàng vào Session
            Session["CartItemCount"] = cartItemCount; ;

            // nếu user not null chạy khối if
            if (user != null)
            {              
                // lấy ra danh sách các items từ database
                var cartWithProducts = cartItems.Select(item => new CartItemViewModel
                {
                    CartItemId = item.Id,
                    ProductId = item.Idcay,
                    ProductName = db.Cays.FirstOrDefault(p => p.Id == item.Idcay).Tencay,
                    Price = db.Cays.FirstOrDefault(p => p.Id == item.Idcay).Dongia,
                    Quantity = item.soluong,
                    TotalPrice = item.tonggiatien,
                    ProductImage = db.Cays.FirstOrDefault(p => p.Id == item.Idcay).Hinhanh
                }).ToList();
                // trả về danh sách
                return View(cartWithProducts);
            }
            else
            {
                // CHuyển đến trang đăng nhập nếu user = null
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
        }


        // sử dụng phương thức post lấy 2 giá trị được đẩy lên
        [HttpPost]
        // Lấy id và số lượng từ int form trong details
        public ActionResult Add(int variantId, int quantity)
        {
            // kiêm tra số  lượng và báo lỗi chuyền về trang chủ
            if (quantity <= 0)
            {
                ModelState.AddModelError("", "Số lượng không hợp lệ.");
                return RedirectToAction("Index", "Home");
            }

            // Tìm sản phẩm theo id của nó
            var product = db.Cays.FirstOrDefault(x => x.Id == variantId);  // Use variantId here
            // Nếu sản phẩm tìm được bị rỗng  báo lỗi
            if (product == null)
            {
                // Product not found
                return HttpNotFound();
            }

            // Nếu thêm sản phẩm mà vuotj quá số lượng tồn kho thông bào không đủ hàng
            if (quantity > product.Soluong)
            {
                ModelState.AddModelError("", "Không đủ hàng trong kho.");
                return RedirectToAction("Index", "Home");
            }
            // tạo biến chứa session user
            var user = Session["User"] as K22CNT4_HVK_TTCD1.Models.NguoiDung;
            
           // Nếu người dùng rỗng thì trả về trang đăng nhập
            if (user == null)
            {        
                // If no user is logged in, redirect to login page
                return RedirectToAction("DangNhap", "Home", new { area = "" });
            }
            // tạo một biến chứa id của người dùng đang đăng nhập ddudwocwj lấy từ session
            var userId = user.Id; // Get the user ID

            // Kiểm tra sản phẩm tồn tại hay chưa
            var existingCartItem = db.GioHangs
                .FirstOrDefault(g => g.Idnguoidung == userId && g.Idcay == variantId);  // Use variantId here

            // Nếu tồn tại thay đổi số lượng và tổng giá tiền
            if (existingCartItem != null)
            {
                existingCartItem.soluong += quantity;
                existingCartItem.tonggiatien = existingCartItem.soluong * product.Dongia;
                // lưu thay đổi
                db.Entry(existingCartItem).State = EntityState.Modified;
            }
            else
            {
                // nếu sản phẩm chưa tồn tại tạo mới giỏ hàng chứa sản phẩm
                var newCartItem = new GioHang
                {
                    Idnguoidung = userId,
                    Idcay = variantId,  // Use variantId here
                    soluong = quantity,
                    tonggiatien = quantity * product.Dongia,
                };
                // Lưu giỏ hàng vào db
                db.GioHangs.Add(newCartItem);
            }
            // lưu thay đổi
            db.SaveChanges();
           //  chuyển về trang hiển thị của giỏ hàng
            return RedirectToAction("Index", "Cart");
        }

        // Xóa sản phẩm từ giỏ hàng
        // Lấy id [get] form chạy Jquery xong đến Ajax
        public ActionResult Delete(int id)
        {
            // Kiểm tra sản phẩm 
            var cartItem = db.GioHangs.FirstOrDefault(g => g.Id == id);
            // Nếu tìm được cho nó cút
            if (cartItem != null)
            {
                // xóa sản phẩm khỏi giỏ hàng 
                db.GioHangs.Remove(cartItem); // Remove item from the cart
                db.SaveChanges();
            }
            // Trả về trang giển thị
            return RedirectToAction("Index", "Cart");
        }

    }

}


