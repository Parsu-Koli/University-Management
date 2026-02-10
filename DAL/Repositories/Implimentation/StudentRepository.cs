using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories.Implimentation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) 
            => _context = context;

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            return await _context.SaveChangesAsync()>0;
           
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var result = await GetStudentById(id);
            if(result == null) return false;

            _context.Students.Remove(result);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
