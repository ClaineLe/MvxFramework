using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.ViewModels;
using UnityEngine.Services.LocalizeService;

namespace Playground.ViewModels
{
    public class SplashScreeViewModel : MvxUnityViewModel
    {
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

        public SplashScreeViewModel()
        {
            //Debug.Log("SplashScreeViewModel");
            var localizeSvr = Mvx.IoCProvider.Resolve<IMvxLocalizeService>();
            BtnCloseCommand = new MvxCommand(CloseSelf);
            BtnChineseCommand = new MvxCommand(() => localizeSvr.SetLanguage(LANG.zh_CN));
            BtnEnglishCommand = new MvxCommand(() => localizeSvr.SetLanguage(LANG.en_GB));
            BtnSpriteCommand = new MvxCommand(NextSprite);
            BtnTextureCommand = new MvxCommand(NextTexture);
            //Debug.Log("BtnChineseCommand:"+ BtnChineseCommand.CanExecute());
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