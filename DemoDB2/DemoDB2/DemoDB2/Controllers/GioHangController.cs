using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB2.Models;

namespace DemoDB2.Controllers
{
    public class GioHangController : Controller
    {
        DBThueXeEntities db = new DBThueXeEntities();
        private string strHang = "Hang";
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DatHang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session[strHang] == null)
            {
                List<Hang> lshang = new List<Hang>
                {
                    new Hang(db.XEs.Find(id),1)
                };
                Session[strHang] = lshang;
            }
            else
            {
                List<Hang> lshang = (List<Hang>)Session[strHang];
                int check = isexitstingCheck(id);
                if (check == 0)
                {
                    lshang.Add(new Hang(db.XEs.Find(id), 1));
                }
                else
                {
                    lshang[check].Soluong++;
                }
                Session[strHang] = lshang;
            }
            return View("Index");
        }
        private int isexitstingCheck(int? id)
        {
            List<Hang> lshang = (List<Hang>)Session[strHang];
            for (int i = 0; i < lshang.Count; i++)
            {
                if (lshang[i].Xe.MAXE == id) return i;
            }
            return 0;
        }
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = isexitstingCheck(id);
            List<Hang> lshang = (List<Hang>)Session[strHang];
            lshang.RemoveAt(check);
            return View("Index");
        }
    }
}