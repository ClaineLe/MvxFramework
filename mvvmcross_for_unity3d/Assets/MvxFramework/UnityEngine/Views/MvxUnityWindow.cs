using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityWindow : MvxUnityView, IMvxUnityWindow
    {
        
    }

    public abstract class MvxUnityWindow<TViewModel> : MvxUnityWindow, IMvxUnityWindow<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        public MvxFluentBindingDescriptionSet<IMvxUnityView<TViewModel>, TViewModel> CreateBindingSet()
        {
            return this.CreateBindingSet<IMvxUnityView<TViewModel>, TViewModel>();
        }

        public new TViewModel ViewModel
        {
            get => base.ViewModel as TViewModel;
            set => base.ViewModel = value;
        }
    }


}