using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories.Implimentation
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;
        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollment()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<Enrollment?> GetEnrollmentById(int id)
        {
            return await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentId == id);
        }

        public async Task<bool> UpdateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteEnrollment(int id)
        {
            var result = await GetEnrollmentById(id);
            if(result == null) return false;

            _context.Enrollments.Remove(result);
            return await _context.SaveChangesAsync()>0;

        }
    }
}
