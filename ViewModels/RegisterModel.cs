﻿using System.ComponentModel.DataAnnotations;

namespace ThienAspWebApi.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? ConfirmPassWord { get; set; }
    }
}
