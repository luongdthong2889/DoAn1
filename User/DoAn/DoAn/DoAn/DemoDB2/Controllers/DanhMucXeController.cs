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
        public ActionResult SearchOption(double min = double.MinValue, double max = double.MaxValue)
        {
            return View(db.XEs.Include("LOAIXE").Where(p => (double)p.DONGIA >= min && (double)p.DONGIA <= max).ToList());
        }
        public ActionResult Index(string HANGXE, string searchstring, string MAUXE)
        {   if (MAUXE == "Màu Trắng" || MAUXE == "Màu Đỏ"|| MAUXE =="Màu Đen")
            {
                return View(db.XEs.Include("LOAIXE").Where(p =>p.MOTA == MAUXE).ToList());
            }
            if (HANGXE == "Honda" || HANGXE == "Toyota" || HANGXE == "Mescedes")
            {
                return View(db.XEs.Include("LOAIXE").Where(s => s.LOAIXE.HANGSANXUAT == HANGXE).ToList());
            }
            if (searchstring != null)
            {
                return View(db.XEs.Include("LOAIXE").Where(s => s.TENXE.Contains(searchstring) || s.LOAIXE.HANGSANXUAT.Contains(searchstring) || s.LOAIXE.TENLOAIXE.Contains(searchstring)).ToList());
            }
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