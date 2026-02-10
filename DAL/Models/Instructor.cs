using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class Instructor
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }



        // Instructor 1 --- 0..1 OfficeAssignment
        [JsonIgnore]
        public OfficeAssignment? OfficeAssignment { get; set; }

        // Instructor * --- * Course (CourseAssignment)
        [JsonIgnore]
        public ICollection<CourseAssignment>? CourseAssignments { get; set; }

        // Instructor 1 --- * Department (as Administrator)
        [JsonIgnore]
        public ICollection<Department>? Departments { get; set; } 
    }
}
