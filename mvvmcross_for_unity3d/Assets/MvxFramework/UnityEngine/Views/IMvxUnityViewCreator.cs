using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityViewCreator : IMvxCurrentRequest
    {
        IMvxVisualElement CreateView(MvxViewModelRequest request);
        IMvxVisualElement CreateView(IMvxViewModel viewModel);
    }
}