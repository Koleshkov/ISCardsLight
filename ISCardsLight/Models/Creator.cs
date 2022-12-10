


using System.ComponentModel.DataAnnotations;

namespace ISCardsLight.Models
{
    public class Creator
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string FirstName { get; set; } = "";
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string SecondName { get; set; } = "";
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string MiddleName { get; set; } = "";

        public string FullName => $"{FirstName} {SecondName} {MiddleName}";
        public string ShortName => $"{FirstName} {SecondName[0]}.{MiddleName[0]}.";
    }
}
