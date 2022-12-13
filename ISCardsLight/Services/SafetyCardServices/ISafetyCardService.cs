using ISCardsLight.Models;

namespace ISCardsLight.Services.SafetyCardServices
{
    public interface ISafetyCardService
    {
        Task<bool> CreateSafetyCardAsync(SafetyCard safetyCard);
    }
}
