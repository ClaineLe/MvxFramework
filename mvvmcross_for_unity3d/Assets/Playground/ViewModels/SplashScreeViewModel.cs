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
    public class UnityViewModel : MvxNavigationViewModel
    {
        public IMvxLanguageBinder TextSource => new MvxLanguageBinder(Constants.GeneralNamespace, GetType().Name);

        public UnityViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }
    }
    public class SplashScreeWindowModel : UnityViewModel
    {
        public IMvxCommand ClickButtonCommand { get; }
        public IMvxCommand SwitchAnimCommand { get; }

        public IMvxCommand<string> asdfCommand { get; }

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
        public SplashScreeWindowModel(ILoggerFactory logFactory,IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            ClickButtonCommand = new MvxCommand(() =>
            {
                navigationService.Navigate<SplashScreeViewModel>();
            });

            SwitchAnimCommand = new MvxCommand(() =>
            {
                if (++rawImageIndex >= animNames.Length)
                    rawImageIndex = 0;

                _interaction.Raise(animNames[rawImageIndex]);
            });
        }

    }

    public class SplashScreeViewModel : UnityViewModel
    {
        private IMvxTextProviderBuilder _builder;
        private IMvxTextProviderBuilder builder => _builder ??= Mvx.IoCProvider.Resolve<IMvxTextProviderBuilder>();

        public IMvxCommand BtnChineseCommand { get; }
        public IMvxCommand BtnEnglishCommand { get; }
        public IMvxCommand BtnRefreshCommand { get; }
        public IMvxCommand BtnSpriteCommand { get; }
        public IMvxCommand BtnTextureCommand { get; }

        private string _imageAssetKey;
        public string ImageAssetKey
        {
            get => _imageAssetKey;
            set => SetProperty(ref _imageAssetKey, value);
        } 
        
        private string _rawImageAssetKey;
        public string RawImageAssetKey
        {
            get => _rawImageAssetKey;
            set => SetProperty(ref _rawImageAssetKey, value);
        }

        public SplashScreeViewModel(ILoggerFactory logFactory,IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            Debug.Log("SplashScreeViewModel");
            BtnRefreshCommand = new MvxCommand(() => RaisePropertyChanged(() => TextSource));
            BtnChineseCommand = new MvxCommand(() => PickLanguage(string.Empty));
            BtnEnglishCommand = new MvxCommand(() => PickLanguage("English"));
            BtnSpriteCommand = new MvxCommand(NextSprite);
            BtnTextureCommand = new MvxCommand(NextTexture);
            Debug.Log("BtnChineseCommand:"+ BtnChineseCommand.CanExecute());
        }
 
        private void PickLanguage(string which)
        {
            Debug.Log($"PickLanguage:{which}");
            builder.LoadResources(which);
            BtnRefreshCommand.Execute();
        }

        private int imageIndex = 1;
        private void NextSprite()
        {
            ImageAssetKey = $"d_genericbuhoshechristmas{imageIndex}";
            if (++imageIndex > 3)
                imageIndex = 1;
        }
        
        private int rawImageIndex = 1;
        private void NextTexture()
        {
            RawImageAssetKey = $"d_genericbuhoshe{rawImageIndex}";
            if (++rawImageIndex > 3)
                rawImageIndex = 1;
        }
    }
}