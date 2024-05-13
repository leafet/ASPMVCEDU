using System.ComponentModel.DataAnnotations;

namespace ASPMVCEDU.Models
{
    public class CourseViewModel
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Необходимо указать название курса")]
        [Display(Name = "Название")]
        public required string CourseName { get; set; }

        [Required(ErrorMessage = "Необходимо указать описание курса")]
        [Display(Name = "Описание")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Необходимо указать продолжительность курса")]
        [Display(Name = "Продолжительность")]
        public required int Duration { get; set; }

        [Required(ErrorMessage = "Необходимо указать цену курса")]
        [Display(Name = "Цена")]
        public required int Price { get; set; }
    }
}
