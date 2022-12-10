


using System.ComponentModel.DataAnnotations;

namespace ISCardsLight.Models
{

    public class PassengerCard : BaseCard
    {
        public PassengerCard() : base(cardType: "КНП") { }

        public override string CardName => new string($"{CreationDate.ToShortDateString()}_{CardType}_{ShortName}");
        public bool WorkStopped { get; set; }

        [Required(ErrorMessage = "Введите название организации")]
        public string NameOfOrganization { get; set; } = "";

        [Required(ErrorMessage = "Ввкдите гос. номер автомобиля")]
        public string NumberOfAuto { get; set; } = "";
        public string TypeOfAuto { get; set; } = "0";
        public bool EmergencyKit { get; set; } = true;
        public bool MonitoringSystem { get; set; } = true;
        public bool ForeignObjects { get; set; } = true;
        public bool RoutePassport { get; set; } = true;
        public bool BusPassport { get; set; } = true;
        public bool SeatBeltsFastened { get; set; } = true;
        public bool CargoFixed { get; set; } = true;
        public bool SafeLaneChange { get; set; } = true;
        public bool KeepingDistance { get; set; } = true;
        public bool SpeedLimit { get; set; } = true;
        public bool SafeBehavior { get; set; } = true;
        public bool NoCell { get; set; } = true;
        public bool ControlOfAuto { get; set; } = true;
        public bool NotEat { get; set; } = true;
        public bool UnderstandsRoadConditions { get; set; } = true;
        public bool RoadSignRequirements { get; set; } = true;
        public bool TimelyTurnOffTheLights { get; set; } = true;
        public bool AttentionToPedestrians { get; set; } = true;
        public bool GiveWay { get; set; } = true;
        public bool AutoSafelyInReverse { get; set; } = true;
        public bool HandbrakeUsing { get; set; } = true;
        public bool RestRegime { get; set; } = true;
        public bool Clear { get; set; }
        public bool Snow { get; set; }
        public bool Cloud { get; set; }
        public bool RainHail { get; set; }
        public bool Sun { get; set; }
        public bool Night { get; set; }
        public bool Rain { get; set; }
        public bool Dirt { get; set; }
        public bool Asphalt { get; set; }
        public bool Ice { get; set; }
        public bool Gravel { get; set; }
        public bool OffRoad { get; set; }
        public bool Ground { get; set; }
        public string PassengerComment { get; set; } = "";
        public string Actions { get; set; } = "";
    }
}
