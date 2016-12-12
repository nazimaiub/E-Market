using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pro.Models;
using System.ComponentModel.DataAnnotations;

namespace pro.Models
{
   
    public class login
    {
            [Required(ErrorMessage = "Product Name is required")]
            public string Name { get; set; }
        }
    }
