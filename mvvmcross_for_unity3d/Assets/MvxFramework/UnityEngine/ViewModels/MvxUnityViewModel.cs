using Microsoft.Extensions.Logging;
using MvvmCross.Localization;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.ViewModels
{
    public abstract class MvxUnityViewModel : MvxNavigationViewModel
    {

        public MvxUnityViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }
    }
    
}