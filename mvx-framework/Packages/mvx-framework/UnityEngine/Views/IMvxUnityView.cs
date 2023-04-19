using System.Threading.Tasks;
using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityView 
        : IMvxView
            , IMvxCanCreateUnityView
            , IMvxBindingContextOwner
            , IMvxVisualElement
    {
        MvxViewModelRequest Request { get; set; }
        
        Task<bool> Activate(bool animated);
        Task<bool> Passivate(bool animated);
        Task<bool> Dismiss(bool animated);
        
    }
    public interface IMvxUnityView<TViewModel> : IMvxUnityView, IMvxView<TViewModel> where
        TViewModel : class, IMvxViewModel
    {
        MvxFluentBindingDescriptionSet<IMvxUnityView<TViewModel>, TViewModel> CreateBindingSet();
    }
}