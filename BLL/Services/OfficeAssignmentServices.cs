using DAL.Models;
using DAL.Repositories.Interfaces;


namespace BLL.Services
{
    public class OfficeAssignmentServices
    {
        private readonly IOfficeAssignmentRepository _repo;

        public OfficeAssignmentServices(IOfficeAssignmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<OfficeAssignment>> GetOfficeAssignment()
        {
            return await _repo.GetOfficeAssignment();
        }

        public async Task<OfficeAssignment> AddOfficeAssignment(OfficeAssignment officeAssignment)
        {
            if (officeAssignment == null) throw new ArgumentNullException(nameof(officeAssignment));

            var result = await _repo.AddOfficeAssignment(officeAssignment);
            return result;
        }

        public async Task<OfficeAssignment?> GetOfficeAssById(int id)
        {
            return await _repo.GetOfficeAssById(id);
        }

        public async Task<bool> UpdateOfficeAssignment(OfficeAssignment officeAssignment)
        {
            return await _repo.UpdateOfficeAssignment(officeAssignment);
        }

        public async Task<bool> DeleteOfficeAssignment(int id)
        {
            return await _repo.DeleteOfficeAssignment(id);
        }
    }
}
