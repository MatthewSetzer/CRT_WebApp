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
