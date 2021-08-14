using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace app.ems.ui.ViewModel
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please enter User ID.")]
        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [MinLength(6, ErrorMessage = "Password length should between 6 to 15 characters.")]
        [MaxLength(15, ErrorMessage = "Password length should between 6 to 15 characters.")]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}
