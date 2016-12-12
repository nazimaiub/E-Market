using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace pro.Models
{
    public class Allproducts
    {
        public int proid
        { get; set; }
        public string image { set; get; }
        public string proname { get; set; }
        public double price { get; set; }
        public string city { get; set; }
        public DateTime time { get; set; }
        public string category { get; set; }
    }
}