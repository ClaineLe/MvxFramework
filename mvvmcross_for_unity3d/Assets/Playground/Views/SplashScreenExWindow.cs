using MvxFramework.UnityEngine.Presenters.Attributes;
using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;
using UnityEngine.UI;

namespace Playground.Views
{
    [MvxWindowPresentation(LAYER.top)]
    public class SplashScreenExWindow : MvxUnityWindow<SplashScreeExViewModel>
    {
        public Button button;

        public Text textXX;
        public Text text;

        protected override void OnViewLoaded()
        {
            var setter = CreateBindingSet();
            setter.Bind(this.button).For(v=>v.onClick).To(vm => vm.BtnCommand);
            setter.Bind(this.textXX).For(v => v.text).To(vm => vm.Counter);
            setter.Apply();
        }
    }
}