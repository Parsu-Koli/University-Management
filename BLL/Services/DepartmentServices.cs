using DAL.Models;
using DAL.Repositories.Interfaces;


namespace BLL.Services
{
    public class DepartmentServices
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentServices (IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _repository.GetDepartment();
        }

        public async Task<Department> AddDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            var a = await _repository.AddDepartment(department);
            return a;
        }

        public async Task<Department?> GetDepartmentById(int id)
        {
            return await _repository.GetDepartmentById(id);
        }
         
        public async Task<bool> UpdateDepartment(Department department)
        {
            return await _repository.UpdateDepartment(department);
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            return await _repository.DeleteDepartment(id);
        }
    }
}
