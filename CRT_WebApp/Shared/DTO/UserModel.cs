using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT_WebApp.Shared.DTO
{
    public class UserModel
    {
        public string Email { get; set; }
        [EmailAddress]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(10)]
        public string ConfirmPassword { get; set; }
    }
}
