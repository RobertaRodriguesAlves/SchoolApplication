using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Courses;
using MongoDB.Driver;
using Repositories.BaseRepositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repositories.Courses
{
    public sealed class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly IMongoCollection<Course> collection;

        public CourseRepository(ISchoolDatabaseSettings databaseSettings) : base(databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            collection = mongoDatabase.GetCollection<Course>(typeof(Course).Name);
        }

        public async Task<IEnumerable<Course>> FindAllAsync(CancellationToken cancellationToken)
        {
            return await FindAll();
        }

        public async Task<Course> FindByCodeAsync(string code)
        {
            return await this.collection.Find(course => course.Code.Equals(code)).FirstOrDefaultAsync();
        }

        public async Task DeleteCourseByIdAsync(string courseId)
        {
            await this.collection.DeleteOneAsync(course => course.CourseId.Equals(courseId));
        }
    }
}
