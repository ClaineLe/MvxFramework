using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using MvxFramework.UnityEngine.Views.Base;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityView : IMvxView, IMvxEventSourceUIBehaviour, IMvxBindingContextOwner
    {
        internal void ViewLoaded();
        
        MvxViewModelRequest Request { get; set; }
    }

    public interface IMvxUnityView<TViewModel> : IMvxUnityView, IMvxView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        MvxFluentBindingDescriptionSet<IMvxUnityView<TViewModel>, TViewModel> CreateBindingSet();
    }

}