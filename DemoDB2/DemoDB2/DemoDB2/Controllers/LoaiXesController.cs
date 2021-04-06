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
    public class LOAIXEsController : Controller
    {
        DBThueXeEntities db = new DBThueXeEntities();

        // GET: LOAIXEs
        public ActionResult Index()
        {
            return View(db.LOAIXEs.ToList());
        }

        // GET: LOAIXEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIXE LOAIXE = db.LOAIXEs.Find(id);
            if (LOAIXE == null)
            {
                return HttpNotFound();
            }
            return View(LOAIXE);
        }

        // GET: LOAIXEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOAIXEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLOAIXE,TenLOAIXE,SoCho,SoLuongXe,HangSanXuat")] LOAIXE LOAIXE)
        {
            if (ModelState.IsValid)
            {
                db.LOAIXEs.Add(LOAIXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(LOAIXE);
        }

        // GET: LOAIXEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIXE LOAIXE = db.LOAIXEs.Find(id);
            if (LOAIXE == null)
            {
                return HttpNotFound();
            }
            return View(LOAIXE);
        }

        // POST: LOAIXEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLOAIXE,TenLOAIXE,SoCho,SoLuongXe,HangSanXuat")] LOAIXE LOAIXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(LOAIXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(LOAIXE);
        }

        // GET: LOAIXEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIXE LOAIXE = db.LOAIXEs.Find(id);
            if (LOAIXE == null)
            {
                return HttpNotFound();
            }
            return View(LOAIXE);
        }

        // POST: LOAIXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAIXE LOAIXE = db.LOAIXEs.Find(id);
            db.LOAIXEs.Remove(LOAIXE);
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
