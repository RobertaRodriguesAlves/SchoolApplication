using Contracts.Students;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Students
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<StudentResponse> GetByCpfAsync(string studentCpf);
        Task<StudentResponse> CreateAsync(StudentForCreationRequest studentForCreation, CancellationToken cancellationToken = default);
        Task<StudentResponse> UpdateAsync(StudentForUpdateRequest studentForUpdate, CancellationToken cancellationToken = default);
        Task<string> DeleteAsync(string studentCpf);
    }
}
