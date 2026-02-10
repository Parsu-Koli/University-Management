using DAL.Models;


namespace DAL.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> AddStudent(Student student);
        Task<Student?> GetStudentById(int id);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int id);

    }
}
