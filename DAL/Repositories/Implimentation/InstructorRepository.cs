using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implimentation
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _context;
        public InstructorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Instructor>> GetInstructor()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<Instructor> AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return instructor;
        }

        public async Task<Instructor?> GetInstructorById(int id)
        {
            return await _context.Instructors.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> UpdateInstructor(Instructor instructor)
        {

            _context.Instructors.Update(instructor);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteInstructor(int id)
        {
            var result = await GetInstructorById(id);
            if(result == null) return false;

            _context.Instructors.Remove(result);
            return await _context.SaveChangesAsync()>0;
        }

        
    }
}
