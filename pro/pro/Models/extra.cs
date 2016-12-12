using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pro.Models
{
    public class extra
    {
        public List<string> getarea(int id)
        {
            dbaseEntities1 db = new dbaseEntities1();
            return db.areas.Where(x => x.cid == id).Select(x=>x.areaname).ToList();
        }
    }
}