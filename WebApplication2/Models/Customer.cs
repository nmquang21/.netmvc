using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Customer
    {
        public string id { get; set; }
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter your Email.")]
        public string Email { get; set; }
        public string Phone { get; set; }
        [StringLength(9, MinimumLength = 4)]
        public string Password { get; set; }
        [DisplayName("Confirm--Password")]
        [StringLength(9, MinimumLength = 4)]
        [Compare("Password", ErrorMessage = "The specified passwords do not match with the Password field.")]
        public string ConfirmPassword { get; set; }
        public string Age { get; set; }
    }
}