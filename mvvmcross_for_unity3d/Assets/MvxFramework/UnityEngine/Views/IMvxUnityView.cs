using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityView 
        : IMvxView
            , IMvxCanCreateUnityView
            , IMvxBindingContextOwner
    {
        MvxViewModelRequest Request { get; set; }

        RectTransform rectTransform { get; }
    }
    public interface IMvxUnityView<TViewModel> : IMvxUnityView, IMvxView<TViewModel> where
        TViewModel : class, IMvxViewModel
    {
        MvxFluentBindingDescriptionSet<IMvxUnityView<TViewModel>, TViewModel> CreateBindingSet();
    }
}