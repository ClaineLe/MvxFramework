using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using UnityEngine;

namespace Playground.ViewModels
{
    public class SplashScreeExViewModel : MvxNavigationViewModel
    {
        public IMvxAsyncCommand BtnCommand { get; }
        private string _counter;
        public string Counter
        {
            get => _counter;
            set => SetProperty(ref _counter, value);
        }

        public SplashScreeExViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            BtnCommand = new MvxAsyncCommand(async () => {  Debug.Log(Counter);
                Counter = "ClaineLe";
            });
        }
    }
}