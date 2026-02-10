using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implimentation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> AddDepartment(Department department)
        {
            _context.Departments.Add(department);   
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department?> GetDepartmentById( int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(D => D.DepartmentId == id);
        }

        public async Task<bool> UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var result = await GetDepartmentById(id);
            if(result == null)  return false; 

            _context.Departments.Remove(result);
            return await _context.SaveChangesAsync()>0;
        }
    }
}
