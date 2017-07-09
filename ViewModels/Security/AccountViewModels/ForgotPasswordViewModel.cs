using System.ComponentModel.DataAnnotations;

namespace ViewModels.Security.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
