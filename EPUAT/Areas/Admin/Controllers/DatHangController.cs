using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPUAT.Models;

namespace EPUAT.Areas.Admin.Controllers
{
    public class DatHangController : Controller
    {
        // GET: Admin/DatHang
        public ActionResult Index()
        {
            // tạo dbContext
            demoEntities4 db = new demoEntities4();
            // lấy ra danh sách các khách hàng truy vấn dữ liệu từ Khachhang
            List<Dathang> lst = db.Dathang.ToList();
            return View(lst);
        }
        public ActionResult Search(int? MKH, string Search)
        {
            demoEntities4 db = new demoEntities4();

            List<Dathang> LKH;
            if (MKH == null && Search == null)
            {
                LKH = db.Dathang.ToList();
            }
            else
            {
                if (MKH != null)
                {
                    LKH = db.Dathang.Where(x => x.MaPhieuDat == MKH).ToList();
                }
                else
                {
                    LKH = db.Dathang.Where(x => x.TenKH.Contains(Search)).ToList();
                }
            }

            //ViewBag.category = new SelectList(db.DanhMucSanPham.ToList(), "MaKH", "TenKH");

            return View(LKH);
        }
    }
}