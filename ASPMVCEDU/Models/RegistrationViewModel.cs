using ASPMVCEDU.Data;
using System.ComponentModel.DataAnnotations;

namespace ASPMVCEDU.Models
{
    public class RegistrationViewModel
    {
        [Key]
        public int RegistrationId { get; set; }

        [Required(ErrorMessage = "Необходимо указать занятие")]
        [Display(Name = "Занятие")]
        public int ClassID { get; set; }
        public string CourseName { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }

        [Required(ErrorMessage = "Необходимо указать студента")]
        [Display(Name = "Студент")]
        public int StudentID { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }

        [Required(ErrorMessage = "Необходимо указать дату начала")]
        [Display(Name = "Дата начала")]
        public required DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Необходимо указать оценку")]
        [Display(Name = "Оценка")]
        public required int Mark { get; set; }
    }
}
