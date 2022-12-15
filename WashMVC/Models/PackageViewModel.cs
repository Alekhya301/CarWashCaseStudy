using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WashMVC.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "PackageName")]
        public string Name { get; set; }


        
      

        [Display(Name = "Price")]
        
        [Required(ErrorMessage = "Price is required")]
       
        public string Price { get; set; }


        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required")]
        [StringLength(60)]
       
        public string Status { get; set; }
    }
}