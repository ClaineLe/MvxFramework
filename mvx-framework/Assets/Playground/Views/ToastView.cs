using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;
using UnityEngine.UI;

namespace Playground.Views
{
    public class ToastView : MvxUnityView<ToastViewModel>
    {
        public Text Content;
        protected override void OnViewLoaded()
        {
            var setter = CreateBindingSet();
            setter.Bind(Content).For(v => v.text).To(vm => vm.Context).OneWay();
            setter.Apply();
        }
    }
}