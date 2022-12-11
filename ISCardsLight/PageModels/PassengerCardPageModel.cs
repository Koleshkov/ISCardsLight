using ISCardsLight.Models;
using ISCardsLight.Services.PassengerCardServices;

namespace ISCardsLight.PageModels
{
    public class PassengerCardPageModel
    {
        public PassengerCard PassengerCard { get; set; } = new();
        public bool IsVisibleSpinner { get; set; }

        public bool IsVisibleMessageBox { get; set; }

        private readonly IPassengerCardService passengerCardService;

        public PassengerCardPageModel(IPassengerCardService passengerCardService)
        {
            this.passengerCardService=passengerCardService;
        }

        public async Task CreateCardAction()
        {
            IsVisibleSpinner=true;
            await passengerCardService.SendPassagnerCardAsync(PassengerCard);
            IsVisibleSpinner=false;
            
        }

        public void CloseMessageBox() => IsVisibleMessageBox=false;
    }
}
