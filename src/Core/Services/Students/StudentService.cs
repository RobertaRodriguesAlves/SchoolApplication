using Contracts.Students;
using Domain.Entities;
using Domain.Repositories.Students;
using Mapster;
using Services.Abstractions.Students;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Students
{
    public sealed class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentResponse> CreateAsync(StudentForCreationRequest studentForCreation, CancellationToken cancellationToken = default)
        {
            if (await _studentRepository.FindByCpfAsync(studentForCreation.StudentCpf) == null)
                return new StudentResponse();
            var student = studentForCreation.Adapt<Student>();
            await _studentRepository.Create(student);
            return student.Adapt<StudentResponse>();
        }

        public async Task<string> DeleteAsync(string studentCpf)
        {
            var student = await _studentRepository.FindByCpfAsync(studentCpf);
            if (student is null)
            {
                return "The student was not found";
            }
            await _studentRepository.DeleteStudentByIdAsync(student.StudentId);
            return "Student deleted";
        }

        public async Task<IEnumerable<StudentResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var student = await _studentRepository.FindAllAsync(cancellationToken);
            return student.Adapt<IEnumerable<StudentResponse>>();
        }

        public async Task<StudentResponse> GetByCpfAsync(string studentCpf)
        {
            var student = await _studentRepository.FindByCpfAsync(studentCpf);
            return student.Adapt<StudentResponse>();
        }

        public async Task<StudentResponse> UpdateAsync(StudentForUpdateRequest studentForUpdate, CancellationToken cancellationToken = default)
        {
            var student = await _studentRepository.FindByCpfAsync(studentForUpdate.StudentCpf);
            if (student is null)
            {
                return new StudentResponse();
            }
            student.Name = studentForUpdate.Name;
            await _studentRepository.UpdateStudentAsync(student.StudentId, student);
            //await _studentRepository.Update(student.StudentId, student);
            return student.Adapt<StudentResponse>();
        }
    }
}
