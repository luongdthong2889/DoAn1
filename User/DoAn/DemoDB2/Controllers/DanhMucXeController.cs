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
        public ActionResult Index(string HANGXE,string searchstring,string SOCHO,string TEN)
        {
            if (HANGXE == "Honda" || HANGXE == "Toyota" || HANGXE == "Mescedes")
            {
                return View(db.XEs.Include("LOAIXE").Where(s => s.LOAIXE.HANGSANXUAT == HANGXE).ToList());
            }
            //if (searchstring != null)
            //{
            //    return View(db.XEs.Include("LOAIXE").Where(s => s.TENXE.Contains(searchstring) || s.LOAIXE.HANGSANXUAT.Contains(searchstring)).ToList());
            //}

            //if (SOCHO == "4")
            //{
            //    int cho = 7;
            //    return View(db.XEs.Include("LOAIXE").Where(s => s.LOAIXE.SOCHO == cho).ToList());
            //}
            //if (SOCHO == "7")

            //{
            //    int cho = 7;
            //    return View(db.XEs.Include("LOAIXE").Where(s => s.LOAIXE.SOCHO == cho).ToList());
            //}
            if (TEN == "OPPP - 2018")
            {

                return View(db.XEs.Include("LOAIXE").Where(s => s.LOAIXE.TENLOAIXE == TEN).ToList());
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