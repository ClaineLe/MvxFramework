using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.ViewModels;
using UnityEngine;

namespace Playground.ViewModels
{
    public class SplashScreeWindowModel : MvxUnityViewModel
    {
        public IMvxCommand ClickButtonCommand { get; }
        public IMvxCommand SwitchAnimCommand { get; }

        public IMvxCommand ToastButtonCommand { get; }
        public IMvxCommand DialogButtonCommand { get; }
        public IMvxCommand LoadingButtonCommand { get; }
        
        private MvxInteraction<string> _interaction = new MvxInteraction<string>();
        public IMvxInteraction<string> Interaction => _interaction;

        private int rawImageIndex = 1;

        private string[] animNames = new[]
        {
            "Position",
            "Rotation",
            "Scale",
            "",
        };

        public SplashScreeWindowModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(
            logFactory, navigationService)
        {
            ClickButtonCommand = new MvxCommand(() => { navigationService.Navigate<SplashScreeViewModel>(); });

            ToastButtonCommand = new MvxCommand(() => { Debug.Log("Toast"); });
            DialogButtonCommand = new MvxCommand(() => { Debug.Log("Dialog");});
            LoadingButtonCommand = new MvxCommand(() => { Debug.Log("Loading");});
            
            SwitchAnimCommand = new MvxCommand(() =>
            {
                if (++rawImageIndex >= animNames.Length)
                    rawImageIndex = 0;

                _interaction.Raise(animNames[rawImageIndex]);
            });
        }
    }
}