using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Reflection.Metadata;

namespace BLL.Services
{
    public class CourseServices
    {
        private readonly ICourseRepository _courseRepository;

        public CourseServices(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        //--------------------------------------Get Course--------------------------------------------
        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _courseRepository.GetCourseAsync();
        }

        //-------------------------------------Post Course--------------------------------------------

        public async Task<Course> AddCourseAsync(Course course)
        {
            if(course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var addedCourse = await _courseRepository.AddCourseAsync(course);
            return addedCourse;
        }

        public async Task<Course?> GetCoursebyId(int id)
        {
            return await _courseRepository.GetCoursebyId(id);
        }

        public async Task<bool> UpdateCourse(Course course)
        {
            return await _courseRepository.UpdateCourse(course);
        }
        
        public async Task<bool> DeleteCourse(int id)
        {
            return await _courseRepository.DeleteCourse(id);
        }
    }
}
