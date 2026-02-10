using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; }
        public int StudentId {  get; set; }
        [JsonIgnore]
        public Course? Course { get; set; }
        [JsonIgnore]
        public Student? Student { get; set; }
    }
}
