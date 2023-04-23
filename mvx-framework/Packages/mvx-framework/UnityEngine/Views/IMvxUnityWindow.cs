using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityWindow : IMvxUnityView
    {
        MvxLinkedStack<IMvxUnityView> LinkedStack { get; }

        void AddChild(IMvxUnityView view, bool enterStack = true);
        void RemoveChild(IMvxUnityView view);
    }

    public interface IMvxUnityWindow<TViewModel> : IMvxUnityWindow, IMvxUnityView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
    }
}