using System.ComponentModel.DataAnnotations;

namespace Capo.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}