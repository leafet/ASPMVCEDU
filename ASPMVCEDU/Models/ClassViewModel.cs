using ASPMVCEDU.Data;
using System.ComponentModel.DataAnnotations;

namespace ASPMVCEDU.Models
{
    public class ClassViewModel
    {
        [Key]
        public int ClassId { get; set; }

        public required Course Course { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public required Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }

        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }

        public required int Duration { get; set; }
    }
}
