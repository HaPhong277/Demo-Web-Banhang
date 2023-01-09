using EPUAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace EPUAT.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        public ActionResult Index()
        {
            // tạo dbContext
            demoEntities4 db = new demoEntities4();
            // lấy ra danh sách các sản phẩm truy vấn dữ liệu từ Category
            List<SanPham> lst = db.SanPham.ToList();
            var check1 = (from item in db.SanPham orderby item.Gia ascending select item).ToList();
            var check2 = (from item in db.SanPham orderby item.Gia descending select item).ToList();
            return View(lst);
        }
        public ActionResult SanPham()
        {
            // tạo dbContext
            demoEntities4 db = new demoEntities4();
            // lấy ra danh sách các sản phẩm truy vấn dữ liệu từ Category
            List<SanPham> lst = db.SanPham.ToList();
            return View(lst);
        }
        public ActionResult Detail(int id)
        {
            demoEntities4 db = new demoEntities4();
            var objproduct = db.SanPham.Where(n => n.Id == id).FirstOrDefault();
            return View(objproduct);
        }
        public ActionResult SanPham1()
        {
            // tạo dbContext
            demoEntities4 db = new demoEntities4();
            // lấy ra danh sách các sản phẩm truy vấn dữ liệu từ Category
            List<SanPham> lst = db.SanPham.ToList();
            //var check1 = (from item in db.SanPham  where item.IdSP == 1 select item.Name).ToList();
            return View(lst);
        }
        public ActionResult SanPham2()
        {
            // tạo dbContext
            demoEntities4 db = new demoEntities4();
            // lấy ra danh sách các sản phẩm truy vấn dữ liệu từ Category
            List<SanPham> lst = db.SanPham.ToList();
            //var check1 = (from item in db.SanPham  where item.IdSP == 1 select item.Name).ToList();
            return View(lst);
        }
        public ActionResult SanPham3()
        {
            // tạo dbContext
            demoEntities4 db = new demoEntities4();
            // lấy ra danh sách các sản phẩm truy vấn dữ liệu từ Category
            List<SanPham> lst = db.SanPham.ToList();
            //var check1 = (from item in db.SanPham  where item.IdSP == 1 select item.Name).ToList();
            return View(lst);
        }
    }
}