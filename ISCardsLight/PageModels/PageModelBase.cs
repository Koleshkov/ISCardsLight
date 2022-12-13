using ISCardsLight.Models;
using ISCardsLight.Services.PassengerCardServices;

namespace ISCardsLight.PageModels
{
    public class PageModelBase
    {
        public bool IsVisibleSpinner { get; set; }
        public bool IsVisibleMessageBox { get; set; }

        public void CloseMessageBox() => IsVisibleMessageBox=false;

        public virtual Task CreateCardAsync()
        {
            return Task.CompletedTask;
        }
    }
}
