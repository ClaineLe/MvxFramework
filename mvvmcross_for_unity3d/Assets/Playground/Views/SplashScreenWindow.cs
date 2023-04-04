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

        public Text TxtContext;

        protected override void OnViewLoaded()
        {
            var setter = CreateBindingSet();
            setter.Bind(this.BtnChinese).To(vm => vm.BtnChineseCommand);
            setter.Bind(this.BtnEnglish).To(vm => vm.BtnEnglishCommand);
            setter.Bind(this.BtnRefresh).To(vm => vm.BtnRefreshCommand);
            this.BindLanguage(TxtContext, "text", "ExampleText");
            setter.Apply();
        }
    }
}