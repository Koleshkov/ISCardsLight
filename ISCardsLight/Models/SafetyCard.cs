
using System.ComponentModel.DataAnnotations;

namespace ISCardsLight.Models
{
    public class SafetyCard : BaseCard
    {
        public SafetyCard() : base(cardType: "ЭКФ") { }

        public override string CardName => $"{CardType}_{FullName}_{CreationDate.ToShortDateString()}";

        [Required(ErrorMessage = "Введите должность")]
        public string Position { get; set; } = "";

        [Required(ErrorMessage = "Введите должность")]
        [Phone(ErrorMessage = "Неврный формат номера телефона")]
        public string Phone { get; set; } = "";

        [Required(ErrorMessage = "Введите email")]
        [EmailAddress(ErrorMessage = "Неврный формат Email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage ="Введите название организации")]
        public string Organization { get; set; } = "OOO «Интеллектуальные системы»";

        [Required(ErrorMessage = "Введите подразделение")]
        public string Department { get; set; } = "ПУ/ПП";

        [Required(ErrorMessage = "Введите оъект")]
        public string JobObject { get; set; } = "";

        [Required]
        public string TypeOfAction { get; set; } = "0";

        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Введите действия")]
        public string Actions { get; set; } = "";

        [Required(ErrorMessage = "Введите причины")]
        public string Reasons { get; set; } = "";

        [Required(ErrorMessage = "Введите планируемые мероприятия")]
        public string PlannedEvents { get; set; } = "";

        [Required]
        public string Status { get; set; } = "0";
    }
}
