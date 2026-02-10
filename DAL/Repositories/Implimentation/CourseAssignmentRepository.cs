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
    public class CourseAssignmentRepository : ICourseAssingmentRepository
    {
        private readonly AppDbContext _context;
        public CourseAssignmentRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<List<CourseAssignment>> GetAllCourseAssignmentAsync()
        {
            return await _context.CourseAssignments.ToListAsync();
        }

        public async Task<CourseAssignment> AddCourseAssignment(CourseAssignment assignment)
        {
            _context.CourseAssignments.Add(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<CourseAssignment?> CourseAssignmentByID(int id)
        {
            return await _context.CourseAssignments.FirstOrDefaultAsync(c => c.CourseId == id);
        }

        public async Task<bool> UpdateCourseAssigment(CourseAssignment course)
        {
            _context.CourseAssignments.Update(course);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteCourseAssignment(int id)
        {
            var result = await CourseAssignmentByID(id);
            if (result == null) return false;
            _context.CourseAssignments.Remove(result);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
