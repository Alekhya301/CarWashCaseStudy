using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WashMVC.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "CarModel is required")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "CarModel")]
        public string CarModel { get; set; }




        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required")]
        [StringLength(60)]

        public string Status { get; set; }
    }
}