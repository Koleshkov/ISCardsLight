using ISCardsLight.Models;
using ISCardsLight.Services.PassengerCardServices;
using ISCardsLight.Services.SafetyCardServices;

namespace ISCardsLight.PageModels
{
    public class SafetyCardPageModel : PageModelBase
    {
        public SafetyCard SafetyCard { get; set; } = new();

        private readonly ISafetyCardService safetyCardService;

        public SafetyCardPageModel(ISafetyCardService safetyCardService)
        {
            this.safetyCardService=safetyCardService;
        }

        public async override Task CreateCardAsync()
        {
            IsVisibleSpinner=true;
            await safetyCardService.CreateSafetyCardAsync(SafetyCard);
            IsVisibleSpinner=false;
        }
    }
}
