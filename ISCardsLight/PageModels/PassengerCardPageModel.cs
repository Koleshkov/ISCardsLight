using ISCardsLight.Models;
using ISCardsLight.Pages;
using ISCardsLight.Services.PassengerCardServices;

namespace ISCardsLight.PageModels
{
    public class PassengerCardPageModel : PageModelBase
    {
        public PassengerCard PassengerCard { get; set; } = new();


        private readonly IPassengerCardService passengerCardService;

        public PassengerCardPageModel(IPassengerCardService passengerCardService)
        {
            this.passengerCardService=passengerCardService;
        }

        public override async Task CreateCardAsync()
        {
            IsVisibleSpinner=true;
            await passengerCardService.CreatePassagnerCardAsync(PassengerCard);
            IsVisibleSpinner=false;

        }
    }
}
