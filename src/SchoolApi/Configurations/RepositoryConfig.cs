using Domain.Repositories;
using Domain.Repositories.Courses;
using Domain.Repositories.Students;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Courses;
using Repositories.Students;

namespace SchoolApi.Configurations
{
    public class RepositoryConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SchoolDatabaseSettings>(configuration.GetSection(nameof(SchoolDatabaseSettings)));
            services.AddSingleton<ISchoolDatabaseSettings>(provider => provider.GetRequiredService<IOptions<SchoolDatabaseSettings>>().Value);
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}
