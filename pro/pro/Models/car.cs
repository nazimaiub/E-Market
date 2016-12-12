using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace pro.Models
{
    [MetadataType(typeof(carMetaData))]
    public partial class car
    {
        [Compare("password")]
        public string retypepass { get; set; }

        public class carMetaData
        {
            [Required(),StringLength(25)]
            public string brand { get; set; }
            [Required()]
            public string password { get; set; }
            
            [Required()]
            public string phone { get; set; }
            [Required()]
            [RegularExpression(@"[\w|.|-]*@\w*\.[\w|.]*", ErrorMessage = "*  Please Insert Correct Email")]
            public string email { get; set; }
            [Required()]
            public string price { get; set; }
            [Required()]
            public string area { get; set; }
        }
    }
}