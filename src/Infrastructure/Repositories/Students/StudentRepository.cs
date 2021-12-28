using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Students;
using MongoDB.Driver;
using Repositories.BaseRepositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repositories.Students
{
    public sealed class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly IMongoCollection<Student> collection;

        public StudentRepository(ISchoolDatabaseSettings databaseSettings) : base(databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            collection = mongoDatabase.GetCollection<Student>(typeof(Student).Name);
        }

        public async Task<IEnumerable<Student>> FindAllAsync(CancellationToken cancellationToken)
        {
            return await FindAll();
        }

        public async Task<Student> FindByCpfAsync(string studentCpf)
        {
            return await this.collection.Find(student => student.StudentCpf.Equals(studentCpf)).FirstOrDefaultAsync();
        }

        public async Task DeleteStudentByIdAsync(string studentId)
        {
            await this.collection.DeleteOneAsync(student => student.StudentId.Equals(studentId));
        }

        public async Task UpdateStudentAsync(string studentId, Student student)
        {
            await this.collection.ReplaceOneAsync(student => student.StudentId.Equals("_id"), student);
            //await this.collection.UpdateOneAsync(student => student.StudentId.Equals(studentId), student));
        }
    }
}
