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
                if (check == -1)
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
            return -1;
        }
        public ActionResult CapNhatSoLuong(FormCollection frc)
        {
            string[] soLuongs = frc.GetValues("soluong");
            List <Hang> lshang = (List<Hang>)Session[strHang];
            for (int i = 0; i < lshang.Count; i++)
            {
                lshang[i].Soluong = Convert.ToInt32(soLuongs[i]);
            }
            Session[strHang] = lshang;
            return View("Index");
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
        public ActionResult GuiDonDat(FormCollection frc)
        {
            List<Hang> lshang = (List<Hang>)Session[strHang];
            KHACHHANG khachhang = new KHACHHANG()
            {
                TENKHACH = frc["Cusname"],
                SODIENTHOAI = frc["Cusphone"],
                DIACHI = frc["Cusaddress"],
            };
            db.KHACHHANGs.Add(khachhang);
            db.SaveChanges();
            foreach(Hang hang in lshang)
            {
                DONDATXE dondat = new DONDATXE()
                {
                    MAKHACH = khachhang.MAKHACHHANG,
                    NGAYDAT = DateTime.Now,
                    NGAYTRA = DateTime.Parse(frc["CusDate"]),
                    MATRANGTHAI = 1,
                };
                db.DONDATXEs.Add(dondat);
                db.SaveChanges();
                CHITIETDONDAT chitietdondat = new CHITIETDONDAT()
                {
                    MADATXE = dondat.MADATXE,
                    MAXE = hang.Xe.MAXE,
                    SOLUONG = hang.Soluong,
                };
                db.CHITIETDONDATs.Add(chitietdondat);
                db.SaveChanges();
            }
            Session.Remove(strHang);
            return View();
        }
    }
}