using ISCardsLight.Models;

namespace ISCardsLight.Services.PassengerCardServices
{
    public interface IPassengerCardService
    {
        Task<bool> SendPassagnerCardAsync(PassengerCard passengerCard);
    }
}
