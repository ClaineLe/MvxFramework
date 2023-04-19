using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.JsonLocalization;
using UnityEngine;

namespace Playground.ViewModels
{
    public class SplashScreeViewModel : MvxUnityLanguageViewModel
    {
        private IMvxTextProviderBuilder _builder;
        private IMvxTextProviderBuilder builder => _builder ??= Mvx.IoCProvider.Resolve<IMvxTextProviderBuilder>();

        public IMvxCommand BtnChineseCommand { get; }
        public IMvxCommand BtnEnglishCommand { get; }
        public IMvxCommand BtnCloseCommand { get; }
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

        public SplashScreeViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(
            logFactory, navigationService)
        {
            //Debug.Log("SplashScreeViewModel");
            BtnCloseCommand = new MvxCommand(CloseSelf);
            BtnChineseCommand = new MvxCommand(() => PickLanguage(string.Empty));
            BtnEnglishCommand = new MvxCommand(() => PickLanguage("English"));
            BtnSpriteCommand = new MvxCommand(NextSprite);
            BtnTextureCommand = new MvxCommand(NextTexture);
            //Debug.Log("BtnChineseCommand:"+ BtnChineseCommand.CanExecute());
        }

        private void PickLanguage(string which)
        {
            //Debug.Log($"PickLanguage:{which}");
            builder.LoadResources(which);
            RaisePropertyChanged(() => TextSource);
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