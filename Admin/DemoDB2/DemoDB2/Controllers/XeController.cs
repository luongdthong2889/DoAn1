using DemoDB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoDB2.Controllers
{
    public class XeController : Controller
    {
        DBThueXeEntities db = new DBThueXeEntities();
        // GET: DanhSachXe
        //public ActionResult Index()
        //{
        //    return View(db.XEs.ToList());
        //}
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(XE x)
        {
            try
            {
                db.XEs.Add(x);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        public ActionResult Details(int id)
        {
            return View(db.XEs.Where(s => s.MAXE == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(db.XEs.Where(s => s.MAXE == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, XE x)
        {
            db.Entry(x).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.XEs.Where(s => s.MAXE == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, XE x)
        {
            try
            {
                x = db.XEs.Where(s => s.MAXE == id).FirstOrDefault();
                db.XEs.Remove(x);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        public ActionResult Index(string _name)
        {
            if (_name == null)
                return View(db.XEs.ToList());
            else
                return View(db.XEs.Where(s => s.TENXE.Contains(_name)).ToList());
        }
    }
}