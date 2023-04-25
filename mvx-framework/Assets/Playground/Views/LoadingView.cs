using MvvmCross.Binding.BindingContext;
using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;
using UnityEngine.UI;

namespace Playground.Views
{
    public class LoadingView : MvxUnityView<LoadingViewModel>
    {
        public Slider SliderProgress;

        public Text TxtContent;

        public Text TxtProgress;
        
        protected override void OnViewLoaded()
        {
            var setter = CreateBindingSet();
            setter.Bind(SliderProgress).For(v => v.value).To(vm => vm.ProgressValue);
            setter.Bind(TxtProgress).For(v=>v.text).To(vm => vm.TxtProgress);
            setter.Bind(TxtContent).To(vm => vm.Content);
            setter.Apply();
        }
    }
}