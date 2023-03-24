using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Playground.ViewModels
{
    public class SplashScreeViewModel : MvxNavigationViewModel
    {
        public SplashScreeViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }
    }
}