using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class CourseAssignment
    {
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        [JsonIgnore]
        public Course? Course { get; set; }
        [JsonIgnore]
        public Instructor? Instructor { get; set; }
    }
}
