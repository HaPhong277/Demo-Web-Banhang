using EPUAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EPUAT.Controllers
{
    public class CartController : Controller
    {
        demoEntities4 db = new demoEntities4();
        // GET: Cart

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            var pro = db.SanPham.SingleOrDefault(s => s.Id == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "Cart");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "Cart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult update(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["Id"]);
            int quantity = int.Parse(form["quantity"]);
            cart.update(id_pro, quantity);
            return RedirectToAction("ShowToCart", "Cart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.delete(id);
            return RedirectToAction("ShowToCart", "Cart");
        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                total_item = cart.Total_Quantity_in_Cart();
            }
            ViewBag.QuantityCart = total_item;
            return PartialView("BagCart");
        }
        public ActionResult Shopping_Succes()
        {
            return View();
        }
        // check out
        public ActionResult CheckOut(FormCollection form)
        {
            try {
                Cart cart = Session["Cart"] as Cart;
                Khachhang kh = new Khachhang();
                //kh.MaKH = int.Parse(form["MaKH"]);
                kh.TenKH = form["TenKH"];
                kh.SDT = int.Parse(form["SDT"]);
                kh.GioiTinh = form["gioitinh"];
                kh.Email = form["Email"];
                kh.DiaChi = form["Address"];
                db.Khachhang.Add(kh);
                Dathang _oder = new Dathang();
                _oder.ThoiGianDat = DateTime.Now;// thoi gian ngay tai luc dat
                _oder.TrangThai = "DangGiao";
                //_oder.MaPhieuDat = 1;
                _oder.TenKH = form["Name"];
                //_oder.MaKH = int.Parse(form["CodeCustomer"]);
                _oder.MaKH = kh.MaKH;
                _oder.DiaChi = kh.DiaChi;
                db.Dathang.Add(_oder);
                foreach (var item in cart.Items)
                {
                    CTDathang _oder_Detail = new CTDathang();
                    _oder_Detail.Id = item._shopping_Product.Id;
                    _oder_Detail.MaPhieuDat = _oder.MaPhieuDat;
                    _oder_Detail.Soluong = item._shopping_Quantity;
                    _oder_Detail.ThanhTien = (item._shopping_Quantity * item._shopping_Product.Gia);
                    db.CTDathang.Add(_oder_Detail);
                }
                db.SaveChanges();
                cart.ClearCart(); 
                return RedirectToAction("Shopping_Succes", "Cart");
            }
            catch
            {
                return Content("Error CheckOut.please infomation of Customer ... ");
            } 
        } 
    }
}