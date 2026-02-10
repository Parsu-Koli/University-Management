using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class InstructorServices
    {
        private readonly IInstructorRepository _instructor;

        public InstructorServices(IInstructorRepository instructor)
        {
            _instructor = instructor;
        }

        public async Task<IEnumerable<Instructor>> GetInstructor()
        {
            return await _instructor.GetInstructor();
        }

        public async Task<Instructor> AddInstructor(Instructor instructor)
        {
            if(instructor == null) throw new ArgumentNullException( nameof(instructor));

            var result = await _instructor.AddInstructor(instructor);
            return result;
        }

        public async Task<Instructor?> GetInstructorById(int id)
        {
            return await _instructor.GetInstructorById(id);
        }

        public async Task<bool> UpdateInstructor(Instructor instructor)
        {
            return await _instructor.UpdateInstructor(instructor);
        }

        public async Task<bool> DeleteInstructor(int id)
        {
            return await _instructor.DeleteInstructor(id);
        }
    }
}
