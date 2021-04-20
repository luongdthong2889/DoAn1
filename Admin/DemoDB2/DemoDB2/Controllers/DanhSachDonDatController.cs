using DemoDB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoDB2.Controllers
{
    public class DanhSachDonDatController : Controller
    {
        DBThueXeEntities db = new DBThueXeEntities();
        // GET: DanhSachDonDat
        public ActionResult Index()
        {
            return View(db.CHITIETDONDATs.Include("DONDATXE").ToList());
        }
        public ActionResult Details(int id)
        {
            return View(db.CHITIETDONDATs.Where(s => s.MACTDONDAT == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(db.CHITIETDONDATs.Where(s => s.MACTDONDAT == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, DONDATXE ctdd)
        {
            db.Entry(ctdd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.DONDATXEs.Where(s => s.MADATXE == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, DONDATXE ctdd)
        {
            try
            {
                ctdd = db.DONDATXEs.Where(s => s.MADATXE == id).FirstOrDefault();
                db.DONDATXEs.Remove(ctdd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
    }
}