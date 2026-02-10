using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IOfficeAssignmentRepository
    {
        Task<IEnumerable<OfficeAssignment>> GetOfficeAssignment();
        Task<OfficeAssignment> AddOfficeAssignment(OfficeAssignment officeassignment);
        Task<OfficeAssignment?> GetOfficeAssById(int id);
        Task<bool> UpdateOfficeAssignment(OfficeAssignment officeassignment);
        Task<bool> DeleteOfficeAssignment(int id);

    }
}
