using DemoDB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoDB2.Controllers
{
    public class DanhSachLoaiXeController : Controller
    {
        DBThueXeEntities db = new DBThueXeEntities();
        // GET: DanhSachLoaiXe
        //public ActionResult Index()
        //{
        //    return View(db.LOAIXEs.ToList());
        //}
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LOAIXE lx)
        {
            try
            {
                db.LOAIXEs.Add(lx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        public ActionResult Details(int mlx)
        {
            return View(db.LOAIXEs.Where(s => s.MALOAIXE == mlx).FirstOrDefault());
        }
        public ActionResult Edit(int mlx)
        {
            return View(db.LOAIXEs.Where(s => s.MALOAIXE == mlx).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int mlx, LOAIXE lx)
        {
            db.Entry(lx).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int mlx)
        {
            return View(db.LOAIXEs.Where(s => s.MALOAIXE == mlx).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int mlx, LOAIXE lx)
        {
            try
            {
                lx = db.LOAIXEs.Where(s => s.MALOAIXE == mlx).FirstOrDefault();
                db.LOAIXEs.Remove(lx);
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
                return View(db.LOAIXEs.ToList());
            else
                return View(db.LOAIXEs.Where(s => s.TENLOAIXE.Contains(_name)).ToList());
        }
    }
}