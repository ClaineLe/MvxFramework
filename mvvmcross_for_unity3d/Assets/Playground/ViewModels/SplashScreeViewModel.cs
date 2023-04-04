using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Localization;
using MvvmCross.Navigation;
using MvvmCross.Plugin.JsonLocalization;
using MvvmCross.ViewModels;
using Playground.Core;
using UnityEngine;

namespace Playground.ViewModels
{
    public class SplashScreeViewModel : MvxNavigationViewModel
    {
        private IMvxTextProviderBuilder _builder;
        private IMvxTextProviderBuilder builder => _builder ??= Mvx.IoCProvider.Resolve<IMvxTextProviderBuilder>();

        public IMvxLanguageBinder TextSource => new MvxLanguageBinder(Constants.GeneralNamespace, GetType().Name);

        public IMvxCommand BtnChineseCommand { get; }
        public IMvxCommand BtnEnglishCommand { get; }
        public IMvxCommand BtnRefreshCommand { get; }
        
        public SplashScreeViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(
            logFactory, navigationService)
        {
            BtnChineseCommand = new MvxCommand(() => PickLanguage(string.Empty));
            BtnEnglishCommand = new MvxCommand(() => PickLanguage("English"));
            BtnRefreshCommand = new MvxCommand(() => RaisePropertyChanged(() => TextSource));
        }

        private void PickLanguage(string which)
        {
            Debug.Log($"PickLanguage:{which}");
            builder.LoadResources(which);
        }
    }
}