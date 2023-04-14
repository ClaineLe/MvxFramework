using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityViewCreator : IMvxCurrentRequest
    {
        IMvxUnityView CreateView(MvxViewModelRequest request);
        IMvxUnityView CreateView(IMvxViewModel viewModel);
    }
}