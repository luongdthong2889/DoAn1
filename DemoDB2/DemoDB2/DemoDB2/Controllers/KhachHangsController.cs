using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoDB2.Models;

namespace DemoDB2.Controllers
{
    public class KHACHHANGsController : Controller
    {
        private DBThueXeEntities db = new DBThueXeEntities();

        // GET: KHACHHANGs
        public ActionResult Index()
        {
            return View(db.KHACHHANGs.ToList());
        }

        // GET: KHACHHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG KHACHHANG = db.KHACHHANGs.Find(id);
            if (KHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(KHACHHANG);
        }

        // GET: KHACHHANGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KHACHHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhach,TenKhach,DiaChi,SoDienThoai,CMND,TenCoQuan,GioiTinh")] KHACHHANG KHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANGs.Add(KHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(KHACHHANG);
        }

        // GET: KHACHHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG KHACHHANG = db.KHACHHANGs.Find(id);
            if (KHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(KHACHHANG);
        }

        // POST: KHACHHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhach,TenKhach,DiaChi,SoDienThoai,CMND,TenCoQuan,GioiTinh")] KHACHHANG KHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(KHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(KHACHHANG);
        }

        // GET: KHACHHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG KHACHHANG = db.KHACHHANGs.Find(id);
            if (KHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(KHACHHANG);
        }

        // POST: KHACHHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHACHHANG KHACHHANG = db.KHACHHANGs.Find(id);
            db.KHACHHANGs.Remove(KHACHHANG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
