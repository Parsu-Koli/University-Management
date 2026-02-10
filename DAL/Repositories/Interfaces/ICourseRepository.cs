using DAL.Models;
using Microsoft.Identity.Client;
namespace DAL.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCourseAsync();
        Task<Course> AddCourseAsync(Course course);
        Task<Course?> GetCoursebyId(int id);
        Task<bool> UpdateCourse(Course course);
        Task<bool> DeleteCourse(int id);
    }
}
