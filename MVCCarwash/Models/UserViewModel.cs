using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVCCarwash.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Id is required")]
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [StringLength(50, MinimumLength = 0)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Mobile Number")]
        [StringLength(10)]
        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression("[6-9][0-9]{9}", ErrorMessage = "Mobile Number must begin with 6,7,8 or 9")]
        public string PhNumber { get; set; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [StringLength(60)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Role is required")]
        
        [Display(Name = "Role")]

        public string Role { get; set; }

        [Required(ErrorMessage = "Status is required")]
        
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}