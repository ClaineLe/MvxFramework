using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;
using UnityEngine.UI;

namespace Playground.Views
{
    public class SplashScreenWindow : MvxUnityWindow<SplashScreeViewModel>
    {
        public Button BtnChinese;
        public Button BtnEnglish;
        public Button BtnRefresh;
        public Button BtnTexture;
        public Button BtnSprite;

        public Image ImgBoard;
        public RawImage RawImgBoard;
        
        public Text TxtContext;

        protected override void OnViewLoaded()
        {
            var setter = CreateBindingSet();
            setter.Bind(this.BtnChinese).To(vm => vm.BtnChineseCommand);
            setter.Bind(this.BtnEnglish).To(vm => vm.BtnEnglishCommand);
            setter.Bind(this.BtnRefresh).To(vm => vm.BtnRefreshCommand);
            
            setter.Bind(this.BtnTexture).To(vm => vm.BtnTextureCommand);
            setter.Bind(this.BtnSprite).To(vm => vm.BtnSpriteCommand);
            
            setter.Bind(this.ImgBoard).To(vm => vm.ImageAssetKey);
            setter.Bind(this.RawImgBoard).To(vm => vm.RawImageAssetKey);
            this.BindLanguage(TxtContext, "text", "ExampleText", bindingMode: MvxBindingMode.OneWay);
            setter.Apply();
        }
    }
}