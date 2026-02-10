using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        // Navigation
        [JsonIgnore]
        public Department? Department { get; set; }

        // Course 1 --- * Enrollment
        [JsonIgnore]
        public ICollection<Enrollment>? Enrollments { get; set; }

        [JsonIgnore]
        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
    }
}
