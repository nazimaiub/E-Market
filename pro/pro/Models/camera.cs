using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace pro.Models
{
    [MetadataType(typeof(cameraMetaData))]
    public partial class camera
    {
        [Compare("phone")]
        public string confirmphone { get; set; }

        public class cameraMetaData
        {
            [Required]
            public string phone { get; set; }

            [Required]
            public string brandname { get; set; }
        }
    }
}