using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartment();
        Task<Department> AddDepartment(Department department);
        Task<Department?> GetDepartmentById(int id);
        Task<bool> UpdateDepartment(Department department);
        Task<bool> DeleteDepartment(int id);
    }
}
