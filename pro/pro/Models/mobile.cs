using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pro.Models
{
    [MetadataType(typeof(mobileMetaData))]
    public partial class mobile
    {
        public class  mobileMetaData
        {
            [Required]
            public string brandname { get; set; }
            [Required]
            public string modelno { get; set; }
            

            [Required]
            public double price { get; set; } 

             
        }
        


    }
}