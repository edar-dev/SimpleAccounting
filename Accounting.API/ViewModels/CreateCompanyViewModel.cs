using System.ComponentModel.DataAnnotations;

namespace Accounting.API.ViewModels
{
    public class CreateCompanyViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}