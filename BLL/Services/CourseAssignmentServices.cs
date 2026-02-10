using DAL.Models;
using DAL.Repositories.Implimentation;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseAssignmentServices
    {
        private readonly ICourseAssingmentRepository _course;
        public CourseAssignmentServices(ICourseAssingmentRepository course)
        {
            _course = course;
        }

        public async Task<IEnumerable<CourseAssignment>> GetAllCourseAssignmentAsync()
        {
            return await _course.GetAllCourseAssignmentAsync();
        }

        public async Task<CourseAssignment> AddCourseAssignment(CourseAssignment assignment)
        {
            if (assignment == null)
            {
                throw new ArgumentNullException(nameof(assignment));
            }

            var addedCourse = await _course.AddCourseAssignment(assignment);
            return addedCourse;
        }

        public async Task<CourseAssignment?> CourseAssignmentByID(int id)
        {
            return await _course.CourseAssignmentByID(id);
        }

        public async Task<bool> UpdateCourseAssigment(CourseAssignment course)
        {

            return await _course.UpdateCourseAssigment(course);
        }

        public async Task<bool> DeleteCourseAssignment(int id)
        {
            return await _course.DeleteCourseAssignment(id);
        }
    }
}
