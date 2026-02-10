using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EnrollmentServices 
    {
        private readonly IEnrollmentRepository _enroll;
        public EnrollmentServices (IEnrollmentRepository enroll)
        {
            _enroll = enroll;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollment()
        {
            return await _enroll.GetEnrollment();
        }

        public async Task<Enrollment> AddEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
            {
                throw new ArgumentNullException(nameof(enrollment));
            }
            var result = await _enroll.AddEnrollment(enrollment);
            return result;
        }

        public async Task<Enrollment?> GetEnrollmentById(int id)
        {
            return await _enroll.GetEnrollmentById(id);
        }

        public async Task<bool> UpdateEnrollment(Enrollment enrollment)
        {
            return await _enroll.UpdateEnrollment(enrollment);
        }

        public async Task<bool> DeleteEnrollment(int id)
        {
            return await _enroll.DeleteEnrollment(id);
        }
     }
}
