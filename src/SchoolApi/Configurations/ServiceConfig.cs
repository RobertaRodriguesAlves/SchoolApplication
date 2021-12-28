using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions.Courses;
using Services.Abstractions.Students;
using Services.Courses;
using Services.Students;

namespace SchoolApi.Configurations
{
    public class ServiceConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
        }
    }
}
