using ISCardsLight.Models;
using ISCardsLight.Services.PassengerCardServices;

namespace ISCardsLight.PageModels
{
    public class PassengerCardPageModel
    {
        public PassengerCard PassengerCard { get; set; } = new();

        private readonly IPassengerCardService passengerCardService;

        public PassengerCardPageModel(IPassengerCardService passengerCardService)
        {
            this.passengerCardService=passengerCardService;
        }

        public async Task CreateCardAction()
        {
            await passengerCardService.SendPassagnerCardAsync(PassengerCard);
            await Task.CompletedTask;
        }
    }
}
