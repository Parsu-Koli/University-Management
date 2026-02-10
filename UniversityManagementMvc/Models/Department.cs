using Microsoft.VisualBasic;

namespace UniversityManagementMvc.Models
{
    public class Department
    {
        public int departmentId { get; set; }
        public string Name { get; set; }
        public int Budget {  get; set; }
        public DateTime? StartDate { get; set; }
        public int InstructorId {  get; set; }
    }
}
