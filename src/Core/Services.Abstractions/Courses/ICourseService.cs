using Contracts.Courses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions.Courses
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<CourseResponse> GetByCodeAsync(string courseCode);
        Task<CourseResponse> CreateAsync(CourseForCreationRequest courseForCreation, CancellationToken cancellationToken = default);
        Task<CourseResponse> UpdateAsync(CourseForUpdateRequest courseForUpdate, CancellationToken cancellationToken = default);
        Task<string> DeleteAsync(string courseCode);
    }
}
