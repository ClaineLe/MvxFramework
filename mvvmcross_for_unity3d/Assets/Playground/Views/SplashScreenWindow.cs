using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;
using UnityEngine.UI;

namespace Playground.Views
{


    public class SplashScreenWindow : MvxUnityWindow<SplashScreeWindowModel>
    {
        public Button ClickButton;
        protected override void OnViewLoaded()
        { 
            var setter = CreateBindingSet();
            setter.Bind(this.ClickButton).To(vm => vm.ClickButtonCommand);
            setter.Apply();
        }
    }
}