﻿using System.ComponentModel.DataAnnotations;

namespace ASPMVCEDU.Models
{
    public class StudentViewModel
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Необходимо указать имя")]
        [Display(Name = "Имя")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Необходимо указать Фамилию")]
        [Display(Name = "Фамилия")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Необходимо указать адресс")]
        [Display(Name = "Адресс")]
        public required string Adress { get; set; }

        [Required(ErrorMessage = "Необходимо указать E-mail")]
        [Display(Name = "E-mail")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Необходимо указать телефон")]
        [Display(Name = "Телефон")]
        public required string Phone { get; set; }
    }
}
