using System.ComponentModel.DataAnnotations;

namespace Accounting.ViewModels
{
    public class CreateCompanyViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}