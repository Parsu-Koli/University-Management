using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories.Implimentation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Course>> GetCourseAsync()
        {
            return await _appDbContext.Courses.ToListAsync(); 
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            _appDbContext.Courses.Add(course);
            await _appDbContext.SaveChangesAsync();
            return course;
        }

        
        public async Task<Course?> GetCoursebyId(int id)
        {
            return await _appDbContext.Courses.FirstOrDefaultAsync(c=> c.CourseId == id);
        }

        public async Task<bool> UpdateCourse(Course course)
        {
            _appDbContext.Courses.Update(course);
            return await _appDbContext.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            var c= await GetCoursebyId(id);
            if(c==null) return false;

            _appDbContext.Courses.Remove(c);
            return await _appDbContext.SaveChangesAsync()>0;
        }
    }
}
