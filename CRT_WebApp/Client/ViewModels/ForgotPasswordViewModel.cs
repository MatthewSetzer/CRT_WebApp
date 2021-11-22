using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRT_WebApp.Client.ViewModels
{
  public class ForgotPasswordViewModel
  {
    [Required]
    public string Email { get; set; }
    public string Username { get; set; }
  }
}
