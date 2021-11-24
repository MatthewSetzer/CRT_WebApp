using System.ComponentModel.DataAnnotations;

namespace CRT_WebApp.Client.ViewModels
{
  public class LoginViewModel
  {
    [Required]
    public string Password { get; set; }
    public string Username { get; set; }
  }
}
