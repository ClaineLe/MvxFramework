using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityView : IMvxView, IMvxBindingContextOwner
    {
        void ViewLoaded();
        MvxViewModelRequest Request { get; set; }
    }

    public interface IMvxUnityView<TViewModel> : IMvxUnityView, IMvxView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        MvxFluentBindingDescriptionSet<IMvxUnityView<TViewModel>, TViewModel> CreateBindingSet();
    }

}