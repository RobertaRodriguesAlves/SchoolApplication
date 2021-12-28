using System.ComponentModel.DataAnnotations;

namespace Contracts.Courses
{
    public class CourseForCreationRequest
    {
        [Required(ErrorMessage = "The course's name is required")]
        [StringLength(80, ErrorMessage = "The course's name need to have {0} maximum length")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The course's code is required")]
        [StringLength(20, ErrorMessage = "The course's code need to have {0} maximum length")]
        public string Code { get; set; }
    }
}
