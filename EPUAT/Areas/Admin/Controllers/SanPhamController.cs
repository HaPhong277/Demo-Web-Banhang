using EPUAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;



namespace EPUAT.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            // tạo dbContext
            demoEntities4 db = new demoEntities4();
            // lấy ra danh sách các sản phẩm truy vấn dữ liệu từ Category
            List<SanPham> lst = db.SanPham.ToList();
            //var check1 = (from item in db.SanPham orderby item.Gia ascending select item).ToList();
            return View(lst);
        }
        public ActionResult Add()

        {
            return View();
        }

        //POST: Add category from model
        [HttpPost]
        public ActionResult Add(SanPham obj)
        {
            //Thuc hien insert obj vao db
            try
            {
                //B1: tao dbContext
                demoEntities4 db = new demoEntities4();
                var f = Request.Files["fileImg"];
                if (f != null && f.ContentLength > 0)
                {
                    string[] ext = f.FileName.Split('.');
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + ext[ext.Length - 1];
                    string path = Server.MapPath("~/images/" + fileName);
                    f.SaveAs(path);
                    obj.images = "/images/" + fileName;
                }
                //B2: thực hiện truy vấn thêm dữ liệu
                db.SanPham.Add(obj);
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
        public ActionResult Delete(int ID)
        {
            // lấy dữ liệu của Category theo Id tương ứng
            demoEntities4 db = new demoEntities4();
            SanPham obj = db.SanPham.Find(ID);
            return View(obj);
        }
        public ActionResult DeleteByID(int ID)
        {
            demoEntities4 db = new demoEntities4();
            SanPham obj = db.SanPham.Find(ID);
            db.SanPham.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int ID)
        {
            // lấy dữ liệu của Category theo Id tương ứng
            demoEntities4 db = new demoEntities4();
            SanPham SP = db.SanPham.Find(ID);
            return View(SP);
        }
        public ActionResult EditbyID(SanPham SP)
        {
            // lấy dữ liệu của Category theo Id tương ứng
            demoEntities4 db = new demoEntities4();
            var f = Request.Files["fileImg"];
            if (f != null && f.ContentLength > 0)
            {
                string[] ext = f.FileName.Split('.');
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + '.' + ext[ext.Length - 1];
                string path = Server.MapPath("~/images/" + fileName);
                f.SaveAs(path);
                SP.images = "/images/" + fileName;
                db.Entry(SP).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Product
        public ActionResult Search(int? IdSP, string Search)
        {
            demoEntities4 db = new demoEntities4();
            List<SanPham> LSP;
            if (IdSP == null && Search == null)
            {
                LSP = db.SanPham.ToList();
            }
            else
            {
                if (IdSP != null)
                {
                    LSP = db.SanPham.Where(x => x.Id == IdSP).ToList();
                }
                else
                {
                    LSP = db.SanPham.Where(x => x.Name.Contains(Search)).ToList();
                }
            }

            ViewBag.category = new SelectList(db.DanhMucSanPham.ToList(), "id", "NameSP");

            return View(LSP);
        }
        public ActionResult show(int ID)
        {
            // lấy dữ liệu của Category theo Id tương ứng
            demoEntities4 db = new demoEntities4();
            SanPham SP = db.SanPham.Find(ID);
            return View(SP);
        }
        public ActionResult showbyID(SanPham SP)
        {
            demoEntities4 db = new demoEntities4();
            SanPham obj = db.SanPham.Find(SP);
            List<SanPham> lst = db.SanPham.ToList();
            return View(lst);
        }
    }
}