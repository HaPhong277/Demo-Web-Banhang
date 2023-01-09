using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPUAT.Models;

namespace EPUAT.Areas.Admin.Controllers
{
    public class registerController : Controller
    {
        // GET: Admin/register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        //POST: Add category from model
        [HttpPost]
        public ActionResult Add(TaiKhoan obj)
        {
            //Thuc hien insert obj vao db
            try
            {
                //B1: tao dbContext
                demoEntities4 db = new demoEntities4();
                //B2: thuc thi truy van LinQ
                db.TaiKhoan.Add(obj);
                db.SaveChanges();
                //ViewBag.Message = "Them moi thanh cong";
                return RedirectToAction("Add");
            }
            catch
            {
                ViewBag.Message = "Them moi that bai";
            }
            return View();
        }
    }
}