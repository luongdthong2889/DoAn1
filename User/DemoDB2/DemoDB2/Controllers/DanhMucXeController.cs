using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB2.Models;

namespace DemoDB2.Controllers
{
    public class DanhMucXeController : Controller
    {
        DBThueXeEntities db = new DBThueXeEntities();
        // GET: DanhMucXe
        public ActionResult Index()
        {
            return View(db.XEs.Include("LOAIXE").ToList());
        }
        public ActionResult Detail(int? id)
        {           
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(db.XEs.Include("LOAIXE").Where(x=>x.MAXE == id).FirstOrDefault());
        }
    }
}