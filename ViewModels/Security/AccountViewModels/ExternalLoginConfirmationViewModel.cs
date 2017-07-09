using System.ComponentModel.DataAnnotations;

namespace ViewModels.Security.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
