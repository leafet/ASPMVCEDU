namespace ASPMVCEDU.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }

        public required string CourseName { get; set; }

        public required string Description { get; set; }

        public required int Duration { get; set; }

        public required int Price { get; set; }
    }
}
