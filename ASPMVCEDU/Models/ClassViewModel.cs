using ASPMVCEDU.Data;

namespace ASPMVCEDU.Models
{
    public class ClassViewModel
    {
        public int ClassId { get; set; }

        public required Course Course { get; set; }

        public required Teacher Teacher { get; set; }

        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }

        public required int Duration { get; set; }
    }
}
