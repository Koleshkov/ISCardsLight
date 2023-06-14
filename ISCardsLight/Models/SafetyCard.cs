
using System.ComponentModel.DataAnnotations;

namespace ISCardsLight.Models
{
    public class SafetyCard : BaseCard
    {
        public SafetyCard() : base(cardType: "ЭКФ") { }

        public override string CardName => $"{CardType}_{FullName}_{CreationDate.ToShortDateString()}";

        [Required(ErrorMessage = "Укажите должность")]
        public string Position { get; set; } = "";

        [Required(ErrorMessage = "Укажите номер телефона")]
        [Phone(ErrorMessage = "Неврный формат номера телефона")]
        public string Phone { get; set; } = "";

        [Required(ErrorMessage = "Укажите email")]
        [EmailAddress(ErrorMessage = "Неврный формат Email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Укажите название организации")]
        public string Organization { get; set; } = "OOO «Интеллектуальные системы»";

        [Required(ErrorMessage = "Укажите подразделение")]
        public string Department { get; set; } = "ПУ/ПП";

        [Required(ErrorMessage = "Укажите оъект")]
        public string JobObject { get; set; } = "";

        [Required]
        public string TypeOfAction { get; set; } = "0";

        [Required(ErrorMessage = "Укажите описание")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Укажите принятые меры")]
        public string Actions { get; set; } = "";

        [Required(ErrorMessage = "Укажите причины")]
        public string Reasons { get; set; } = "";

        [Required(ErrorMessage = "Укажите планируемы мероприятия")]
        public string PlannedEvents { get; set; } = "";

        [Required]
        public string Status { get; set; } = "0";

        [Required(ErrorMessage = "Укажите ответственное лицо")]
        public string Responsible { get; set; } = "";

        [Required(ErrorMessage = "Укажите срок исполнения")]
        public DateTime? Deadline { get; set; } = DateTime.Now;
    }
}
