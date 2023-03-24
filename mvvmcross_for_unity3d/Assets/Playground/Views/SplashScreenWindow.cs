using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;
using UnityEngine.UI;

namespace Playground.Views
{
    public class SplashScreenWindow : MvxUnityWindow<SplashScreeViewModel>
    {
        public Button button;
        public override void ViewLoaded()
        {
            base.ViewLoaded();
            using (var set = CreateBindingSet())
            {
                set.Bind(this.button).For(v=>v.onClick).To(vm => vm.BtnCommand);
            }
        }
    }
}