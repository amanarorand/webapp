using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebAppEmpty.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be atleast {2} characters long", MinimumLength = 7)]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}