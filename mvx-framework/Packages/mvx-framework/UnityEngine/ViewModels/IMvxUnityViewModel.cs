using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.ViewModels
{
    public interface IMvxUnityViewModel : IMvxViewModel
    {
        void DismissView();
    }

    public interface IMvxUnityViewModel<in TParameter> : IMvxUnityViewModel, IMvxViewModel<TParameter>
    {
    }
}