using System.Threading.Tasks;

namespace MvxFramework.UnityEngine.Services
{
    public interface IMvxLoadingService
    {
        Task ShowLoading<TViewModel>() where TViewModel : MvxLoadingViewModel;
        Task HideLoading();
        void SetContent(string content);
        void SetProgress(float progress);
    }
}