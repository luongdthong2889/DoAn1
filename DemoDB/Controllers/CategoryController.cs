using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB.Models;

namespace DemoDB.Controllers
{
    public class LOAIXEController : Controller
    {
        WebQuanLyThueXeEntities1 database = new WebQuanLyThueXeEntities1();
        // GET: LOAIXE
        //public ActionResult Index()
        //{
        //    return View(database.LOAIXEs.ToList());
        //}
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create (LOAIXE cate)
        {
            try
            {
                database.LOAIXEs.Add(cate);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {
                return Content("Error Create New");
            }
        }
        public ActionResult Details(string id)
        {
            return View(database.LOAIXEs.Where(s => s.MaLoaiXe == id).FirstOrDefault());
        }
        public ActionResult Edit(string id)
        {
            return View(database.LOAIXEs.Where(s => s.MaLoaiXe == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string id, LOAIXE cate)
        {
            database.Entry(cate).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            return View(database.LOAIXEs.Where(s => s.MaLoaiXe == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete (string id, LOAIXE cate)
        {
            try
            {
                cate = database.LOAIXEs.Where(s => s.MaLoaiXe == id).FirstOrDefault();
                database.LOAIXEs.Remove(cate);
                database.SaveChanges();
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
                return View(database.LOAIXEs.ToList());
            else
                return View(database.LOAIXEs.Where(s => s.TenLoaiXe.Contains(_name)).ToList());
        }
    }
}