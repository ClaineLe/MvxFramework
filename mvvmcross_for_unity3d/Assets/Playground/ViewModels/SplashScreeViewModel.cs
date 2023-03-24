using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Playground.ViewModels
{
    public class SplashScreeViewModel : MvxNavigationViewModel
    {
        public IMvxAsyncCommand BtnCommand { get; }

        public SplashScreeViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }
    }
}