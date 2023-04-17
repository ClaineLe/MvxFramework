using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityWindow : IMvxUnityView
    {
        void AddChild(IMvxUnityView view);
    }

    public interface IMvxUnityWindow<TViewModel> : IMvxUnityWindow, IMvxUnityView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
    }
}