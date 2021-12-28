using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Contracts.Courses
{
    public class CourseForUpdateRequest
    {
        [StringLength(80, ErrorMessage = "The course's name need to have {0} maximum length")]
        public string Name { get; set; }

        [JsonIgnore]
        public string Code { get; private set; }

        public void SetCourseCode(string code) => Code = code; 
    }
}
