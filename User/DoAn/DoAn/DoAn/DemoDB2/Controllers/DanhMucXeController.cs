using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB2.Models;
using PagedList;
using PagedList.Mvc;

namespace DemoDB2.Controllers
{
    public class DanhMucXeController : Controller
    {
        DBThueXeEntities db = new DBThueXeEntities();
        // GET: DanhMucXe
        public ActionResult SearchOption(double min = double.MinValue, double max = double.MaxValue)
        {
            var listsear = db.XEs.Include("LOAIXE").Where(p => (double)p.DONGIA >= min && (double)p.DONGIA <= max).ToList();
            return View(listsear);
        }
        public ActionResult Index(string HANGXE, string searchstring, string MAUXE, int? page)
        {
            int pageSize = 9;
            int pageNum = (page ?? 1);
            if (MAUXE == "Màu Trắng" || MAUXE == "Màu Đỏ"|| MAUXE =="Màu Đen" || MAUXE == "Màu Xanh" || MAUXE == "Màu Nâu")
            {
                var lista = db.XEs.Include("LOAIXE").Where(p => p.MOTA == MAUXE).ToList();
                return View(lista.ToPagedList(pageNum, pageSize));
            }
            if (HANGXE == "Honda" || HANGXE == "Toyota" || HANGXE == "Mercedes"|| HANGXE == "Ford"|| HANGXE == "Hyundai" || HANGXE == "Mitsubishi" || HANGXE == "VinFast" || HANGXE == "Kia" || HANGXE == "Mazda")
            {
                var listb = db.XEs.Include("LOAIXE").Where(s => s.LOAIXE.HANGSANXUAT == HANGXE).ToList();
                return View(listb.ToPagedList(pageNum, pageSize));
            }
            if (searchstring != null)
            {
                var listc = db.XEs.Include("LOAIXE").Where(s => s.TENXE.Contains(searchstring) || s.LOAIXE.HANGSANXUAT.Contains(searchstring) || s.LOAIXE.TENLOAIXE.Contains(searchstring)).ToList();
                return View(listc.ToPagedList(pageNum, pageSize));
            }
            var list = db.XEs.Include("LOAIXE").ToList();
            return View(list.ToPagedList(pageNum, pageSize));

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