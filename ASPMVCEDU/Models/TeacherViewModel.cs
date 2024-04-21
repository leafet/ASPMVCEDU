using System.ComponentModel.DataAnnotations;

namespace ASPMVCEDU.Models
{
    public class TeacherViewModel
    {
        [Key]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Необходимо указать имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Необходимо указать фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Необходимо указать специализацию")]
        [Display(Name = "Специализация")]
        public string Specialisation { get; set; }

        [Required(ErrorMessage = "Необходимо указать E-Mail")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необходимо указать телефон")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}
