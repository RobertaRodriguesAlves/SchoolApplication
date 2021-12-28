using System.ComponentModel.DataAnnotations;

namespace Contracts.Students
{
    public class StudentForCreationRequest
    {
        [Required(ErrorMessage = "The student's CPF is required")]
        [MinLength(11, ErrorMessage = "The CPF need to have {0} numbers")]
        public string StudentCpf { get; set; }

        [Required(ErrorMessage = "The student's name is required")]
        [StringLength(80, ErrorMessage = "The name need to have {0} maximum length")]
        public string Name { get; set; }
    }
}
