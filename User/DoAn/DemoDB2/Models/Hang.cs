using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDB2.Models
{
    public class Hang
    {
        public XE Xe { get; set; }
        public int Soluong { get; set; }
        public Hang(XE xe, int soluong)
        {
            Xe = xe;
            Soluong = soluong;
        }
    }
}