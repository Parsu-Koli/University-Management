using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<Instructor>> GetInstructor();
        Task<Instructor> AddInstructor(Instructor instructor);
        Task<Instructor?> GetInstructorById(int id);
        Task<bool> UpdateInstructor(Instructor instructor);
        Task<bool> DeleteInstructor(int id);
    }
}
