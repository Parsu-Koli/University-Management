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
    public class OfficeAssignmentRepository : IOfficeAssignmentRepository
    {
        private readonly AppDbContext _context;
        public OfficeAssignmentRepository(AppDbContext context)
            => _context = context;

        public async Task<IEnumerable<OfficeAssignment>> GetOfficeAssignment()
        {
            return await _context.OfficeAssignments.ToListAsync();
        }

        public async Task<OfficeAssignment> AddOfficeAssignment(OfficeAssignment officeassignment)
        {
            _context.OfficeAssignments.Add(officeassignment);
            await _context.SaveChangesAsync();
            return officeassignment;
        }

        public async Task<OfficeAssignment?> GetOfficeAssById(int id)
        {
            return await _context.OfficeAssignments.FirstOrDefaultAsync(o => o.InstructorId == id);
        }

        public async Task<bool> UpdateOfficeAssignment(OfficeAssignment officeassignment)
        {
            _context.OfficeAssignments.Update(officeassignment);
            return await _context.SaveChangesAsync()>0;
            
        }

        public async Task<bool> DeleteOfficeAssignment(int id)
        {
            var result = await GetOfficeAssById(id);
            if (result == null) return false;

            _context.OfficeAssignments.Remove(result);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
