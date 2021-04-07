using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DemoDB2.Models;

namespace DemoDB2.Controllers
{
    public class XeProductController : Controller
    {
        DBThueXeEntities db = new DBThueXeEntities();
        // GET: XeProduct
        public ActionResult Index()
        {
            return View(db.XEs.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}