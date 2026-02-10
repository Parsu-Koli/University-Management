namespace UniversityManagementMvc.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int courseId {  get; set; }
        public string Title { get; set; }
        public int Credits {  get; set; }
        public int DepartmentId {  get; set; }
    }
}
