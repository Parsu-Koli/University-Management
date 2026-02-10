using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ICourseAssingmentRepository
    {
        Task<List<CourseAssignment>> GetAllCourseAssignmentAsync();
        Task<CourseAssignment> AddCourseAssignment(CourseAssignment assignment);
        Task<CourseAssignment?> CourseAssignmentByID(int id);
        Task<bool> UpdateCourseAssigment(CourseAssignment course);
        Task<bool> DeleteCourseAssignment(int id);
    }
}
