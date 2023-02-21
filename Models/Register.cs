using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Register
    {
        [Key]
        public int User_Id { get; set; }

        [Required(ErrorMessage = "Please Enter an Email!")]
        [Display(Name = "Email Address")]
        public string User_EmailAddress { get; set; }

        [Required(ErrorMessage = "Please Enter a Name!")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter a Surname!")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please Enter a Password!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Confirm your Password!!")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, type again!")]
        public string ConfirmPassword { get; set; }
    }
}