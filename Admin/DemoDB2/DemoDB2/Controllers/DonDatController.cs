using DemoDB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoDB2.Controllers
{
    public class DonDatController : Controller
    {
        DBThueXeEntities db = new DBThueXeEntities();
        // GET: DanhSachDonDat
        public ActionResult Index()
        {
            return View(db.CHITIETDONDATs.Include("DONDATXE").ToList());
        }
        public ActionResult SelectTrangThai()
        {
            TRANGTHAI ltrangthai = new TRANGTHAI();
            ltrangthai.ListTrangThai = db.TRANGTHAIs.ToList();
            return PartialView(ltrangthai);
        }
        public ActionResult Edit(int id)
        {
            return View(db.DONDATXEs.Where(s => s.MADATXE == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, DONDATXE dondat)
        {
            db.Entry(dondat).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.DONDATXEs.Where(s => s.MADATXE == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, DONDATXE dondat,CHITIETDONDAT chitiet)
        {
            try
            {
                dondat = db.DONDATXEs.Where(s => s.MADATXE == id).FirstOrDefault();
                chitiet = db.CHITIETDONDATs.Where(s => s.MADATXE == dondat.MADATXE).FirstOrDefault();
                db.CHITIETDONDATs.Remove(chitiet);
                db.DONDATXEs.Remove(dondat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, ERROR DELETE");
            }
        }

        public ActionResult EditDetail(int id)
        {
            return View(db.CHITIETDONDATs.Where(s => s.MACTDONDAT == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditDetail(int id, CHITIETDONDAT chitiet)
        {
            db.Entry(chitiet).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}