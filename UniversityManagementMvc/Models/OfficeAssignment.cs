using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversityManagementMvc.Models
{
    public class OfficeAssignment
    {
        public int instructorId { get; set; }
        public string location { get; set; }
        public string? InstructorName { get; set; }
        public IEnumerable<SelectListItem>? InstructorList { get; set; }
    }
}
