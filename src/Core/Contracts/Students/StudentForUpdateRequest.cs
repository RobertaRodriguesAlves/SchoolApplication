using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Contracts.Students
{
    public class StudentForUpdateRequest
    {
        [JsonIgnore]
        public string StudentCpf { get; private set; }
        public void SetStudentCpf(string studentCpf) => StudentCpf = studentCpf;

        [StringLength(80, ErrorMessage = "The name need to have {0} maximum length")]
        public string Name { get; set; }
    }
}
