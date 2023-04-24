using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.ViewModels
{
    public interface IMvxUnityViewModel : IMvxViewModel
    {
        void CloseSelf();
    }

    public interface IMvxUnityViewModel<in TParameter> : IMvxUnityViewModel, IMvxViewModel<TParameter>
    {
    }
}