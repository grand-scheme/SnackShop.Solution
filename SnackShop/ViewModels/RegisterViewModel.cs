using System.ComponentModel.DataAnnotations;

namespace SnackShop.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email {get;set;}

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password {get;set;}

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Password and confirmation do not match.")]
    public string ConfirmPassword{get;set;}
  }
}