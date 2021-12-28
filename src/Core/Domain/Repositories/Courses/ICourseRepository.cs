using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories.Courses
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<IEnumerable<Course>> FindAllAsync(CancellationToken cancellationToken);
        Task<Course> FindByCodeAsync(string Code);
        Task DeleteCourseByIdAsync(string courseId);
    }
}
