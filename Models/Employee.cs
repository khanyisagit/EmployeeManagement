using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("eMail Address ")]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        [DisplayName("First Name ")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Contact Number")]
        [Required]
        public string ContactNumber { get; set; }

        [DisplayName("Designation")]
        [Required]
        public string Designation { get; set; } 


    }
}