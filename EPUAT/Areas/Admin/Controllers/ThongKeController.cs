using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPUAT.Models;

namespace EPUAT.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            // tạo dbContext
            demoEntities4 db = new demoEntities4();
            // lấy ra danh sách các khách hàng truy vấn dữ liệu từ Khachhang
            List<CTDathang> lst = db.CTDathang.ToList();
            return View(lst);
        }
        public ActionResult Search(int? MKH, int Search)
        {
            demoEntities4 db = new demoEntities4();

            List<CTDathang> LKH;
            if (MKH == null && Search == null)
            {
                LKH = db.CTDathang.ToList();
            }
            else
            {
                if (MKH != null)
                {
                    LKH = db.CTDathang.Where(x => x.MaCTPhieuDat == MKH).ToList();
                }
                else
                {
                    LKH = db.CTDathang.Where(x => x.MaPhieuDat == Search).ToList();
                }
            }

            //ViewBag.category = new SelectList(db.DanhMucSanPham.ToList(), "MaKH", "TenKH");

            return View(LKH);
        }
    }
}