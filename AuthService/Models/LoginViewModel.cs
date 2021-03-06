﻿using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class LoginViewModel
    {
        [Required]
        //[EmailAddress]
        //public string Email { get; set; }
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
