using System.ComponentModel.DataAnnotations;

namespace ISCardsLight.Models
{
    public class BaseCard
    {
        public string CardType { get; } = "";
        public Creator Creator { get; set; } = new();
        public DateTime CreationDate => DateTime.Now;
        public string Responsible { get; set; } = "";
        public DateTime Deadline { get; set; } = DateTime.Now;
        public virtual string CardName { get; set; } = "";

        public BaseCard(string cardType)
        {
            CardType = cardType;
        }
    }
}
