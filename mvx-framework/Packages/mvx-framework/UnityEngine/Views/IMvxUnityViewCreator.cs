using System.Threading.Tasks;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Presenters.Attributes;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityViewCreator : IMvxCurrentRequest
    {
        IMvxVisualElement CreateView(MvxViewModelRequest request);
        IMvxVisualElement CreateView(IMvxViewModel viewModel);
        
        Task<IMvxVisualElement> CreateViewAsync(MvxViewModelRequest request, MvxUnityBasePresentationAttribute attribute);
        Task<IMvxVisualElement> CreateViewAsync(IMvxViewModel viewModel, MvxUnityBasePresentationAttribute attribute);
    }
}