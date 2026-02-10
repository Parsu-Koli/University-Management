using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentServices
    {
        private readonly IStudentRepository _repo;
        public StudentServices (IStudentRepository repo)
            => _repo = repo;

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _repo.GetStudents();
        }

        public async Task<Student> AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            var result = await _repo.AddStudent(student);
            return result;
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _repo.GetStudentById(id);
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            return await _repo.UpdateStudent(student);
        }

        public async Task<bool> DeleteStudent(int id)
        {
            return await _repo.DeleteStudent(id);
        }
    }
}
