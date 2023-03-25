using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;
using UnityEngine.UI;

namespace Playground.Views
{
    public class SplashScreenWindow : MvxUnityWindow<SplashScreeViewModel>
    {
        public Button button;

        public Text textXX;
        public Text text;
        public override void ViewLoaded()
        {
            base.ViewLoaded();
            var setter = CreateBindingSet();
            setter.Bind(this.button).For(v=>v.onClick).To(vm => vm.BtnCommand);
            setter.Bind(this.textXX).For(v => v.text).To(vm => vm.Counter);
            setter.Apply();
        }
    }
}