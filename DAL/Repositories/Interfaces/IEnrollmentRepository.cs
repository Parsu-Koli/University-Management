using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetEnrollment();
        Task<Enrollment> AddEnrollment(Enrollment enrollment);
        Task<Enrollment?> GetEnrollmentById(int id);
        Task<bool> UpdateEnrollment(Enrollment enrollment);
        Task<bool> DeleteEnrollment(int id);
    }
}
