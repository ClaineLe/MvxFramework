using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;
using UnityEngine;
using UnityEngine.UI;
namespace Playground.Views
{
    public class SplashScreenWindow : MvxUnityWindow<SplashScreeWindowModel>
    {
        public Button ClickButton;

        public Image BackGround;
        protected override void OnViewLoaded()
        { 
            Debug.Log("OnViewLoaded");
            var setter = CreateBindingSet();
            setter.Bind(this.ClickButton).To(vm => vm.ClickButtonCommand);
            setter.Apply();
        }
    }
}