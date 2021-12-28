using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories.Students
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<IEnumerable<Student>> FindAllAsync(CancellationToken cancellationToken);
        Task<Student> FindByCpfAsync(string studentCpf);
        Task DeleteStudentByIdAsync(string studentId);
        Task UpdateStudentAsync(string studentId, Student student);
    }
}
