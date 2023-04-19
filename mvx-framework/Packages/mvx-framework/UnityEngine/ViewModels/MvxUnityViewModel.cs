using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.ViewModels
{
    public abstract class MvxUnityViewModel : MvxNavigationViewModel, IMvxUnityViewModel
    {
        public MvxUnityViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory,
            navigationService)
        {
        }

        public void CloseSelf()
        {
            this.NavigationService.Close(this);
        }
    }
}