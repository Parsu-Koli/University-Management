using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartDate { get; set; }

        // Department Administrator (Instructor)
        public int? InstructorId { get; set; }
        [JsonIgnore]
        public Instructor? Instructor { get; set; }

        // Department 1 --- * Course
        [JsonIgnore]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
