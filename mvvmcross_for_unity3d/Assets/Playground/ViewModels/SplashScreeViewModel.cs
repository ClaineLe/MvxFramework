using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Playground.ViewModels
{
    public class SplashScreeViewModel : MvxNavigationViewModel
    {
        public IMvxAsyncCommand BtnCommand { get; }
        private string _counter;
        public string Counter
        {
            get => _counter;
            set => SetProperty(ref _counter, value);
        }

        public SplashScreeViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            BtnCommand = new MvxAsyncCommand(async () => 
            {
                Counter = "ClaineLe";
                await navigationService.Navigate<SplashScreeExViewModel>();
                await navigationService.Close(this);
            });
        }
    }
}