using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB2.Models;

namespace DemoDB2.Controllers
{
    public class TrangChuController : Controller
    {
        DBThueXeEntities db = new DBThueXeEntities();
        // GET: TrangChu
        public ActionResult TrangChu()
        {
            return View(db.LOAIXEs.ToList());
        }
    }
}