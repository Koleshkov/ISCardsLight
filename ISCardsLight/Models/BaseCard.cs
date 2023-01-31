using System.ComponentModel.DataAnnotations;

namespace ISCardsLight.Models
{
    public class BaseCard
    {
        public string CardType { get; } = "";

        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Введите фамилию")]
        public string SecondName { get; set; } = "";

        [Required(ErrorMessage = "Введите отчество")]
        public string MiddleName { get; set; } = "";
        public string FullName => $"{SecondName} {FirstName} {MiddleName}";
        public string ShortName => $"{SecondName} {FirstName[0]}.{MiddleName[0]}.";

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public string Responsible { get; set; } = "";

        public DateTime? Deadline { get; set; } 

        public virtual string CardName { get; set; } = "";

        public BaseCard(string cardType)
        {
            CardType = cardType;
        }
    }
}
