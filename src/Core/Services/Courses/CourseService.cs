using Contracts.Courses;
using Domain.Entities;
using Domain.Repositories.Courses;
using Mapster;
using Services.Abstractions.Courses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Courses
{
    public sealed class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseResponse> CreateAsync(CourseForCreationRequest courseForCreation, CancellationToken cancellationToken = default)
        {
            if (await _courseRepository.FindByCodeAsync(courseForCreation.Code) != null)
            {
                return new CourseResponse();
            }
            var course = courseForCreation.Adapt<Course>();
            await _courseRepository.Create(course);
            return course.Adapt<CourseResponse>();
        }

        public async Task<string> DeleteAsync(string courseCode)
        {
            var course = await _courseRepository.FindByCodeAsync(courseCode);
            if (course is null)
            {
                return "Course's code was not found";
            }
            await _courseRepository.DeleteCourseByIdAsync(course.CourseId);
            return "Course deleted";
        }

        public async Task<IEnumerable<CourseResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var course = await _courseRepository.FindAllAsync(cancellationToken);
            return course.Adapt<IEnumerable<CourseResponse>>();
        }

        public async Task<CourseResponse> GetByCodeAsync(string courseCode)
        {
            var course = await _courseRepository.FindByCodeAsync(courseCode);
            return course.Adapt<CourseResponse>();
        }

        public async Task<CourseResponse> UpdateAsync(CourseForUpdateRequest courseForUpdate, CancellationToken cancellationToken = default)
        {
            var course = await _courseRepository.FindByCodeAsync(courseForUpdate.Code);
            if (course is null)
            {
                return new CourseResponse();
            }
            course.Name = courseForUpdate.Name;
            await _courseRepository.Update(course.CourseId, course);
            return course.Adapt<CourseResponse>();
        }
    }
}
