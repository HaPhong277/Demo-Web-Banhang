using EPUAT.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPUAT.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            // tạo dbContext
            demoEntities4 db = new demoEntities4();
            // lấy ra danh sách các khách hàng truy vấn dữ liệu từ Khachhang
            List<Khachhang> lst = db.Khachhang.ToList();
            return View(lst);
        }
        public ActionResult Add()
        {
            return View();
        }

        //POST: Add category from model
        [HttpPost]
        public ActionResult Add(Khachhang obj)
        {
            try
            {
                //B1: tao dbContext
                demoEntities4 db = new demoEntities4();
                //B2: thực hiện truy vấn thêm dữ liệu
                db.Khachhang.Add(obj);
                db.SaveChanges();
                ViewBag.Message = "Thêm mới thành công";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Thêm mới thất bại";
            }
            return View();
        }
        public ActionResult Delete(int MaKH)
        {
            // lấy dữ liệu của Khachhang theo MaKH tương ứng
            demoEntities4 db = new demoEntities4();
            Khachhang obj = db.Khachhang.Find(MaKH);
            return View(obj);
        }
        public ActionResult DeleteByMaKH(int MaKH)
        {
            demoEntities4 db = new demoEntities4();
            Khachhang obj = db.Khachhang.Find(MaKH);
            db.Khachhang.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int MaKH)
        {
            // lấy dữ liệu của Khachhang theo MaKH tương ứng
            demoEntities4 db = new demoEntities4();
            Khachhang KH = db.Khachhang.Find(MaKH);
            return View(KH);
        }
        public ActionResult EditbyMaKH(Khachhang TKH)
        {
            // lấy dữ liệu của Khachhang theo MaKH tương ứng
            demoEntities4 db = new demoEntities4();
            db.Entry(TKH).State = EntityState.Modified;
            db.SaveChanges();   
            return RedirectToAction("Index");
        }
        public ActionResult Search(int? MKH, string Search)
        {
            demoEntities4 db = new demoEntities4();

            List < Khachhang >  LKH;
            if (MKH == null && Search == null)
            {
                LKH = db.Khachhang.ToList();
            }
            else
            {
                if (MKH != null)
                {
                    LKH = db.Khachhang.Where(x => x.MaKH == MKH).ToList();
                }
                else
                {
                    LKH = db.Khachhang.Where(x => x.TenKH.Contains(Search)).ToList();
                }
            }

            //ViewBag.category = new SelectList(db.DanhMucSanPham.ToList(), "MaKH", "TenKH");

            return View(LKH);
        }
    }
}