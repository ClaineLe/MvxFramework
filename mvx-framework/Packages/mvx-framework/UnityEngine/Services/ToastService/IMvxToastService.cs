using System.Threading.Tasks;
using MvxFramework.UnityEngine.ViewModels;

namespace MvxFramework.UnityEngine.Services
{
    public interface IMvxToastService
    {
        Task<bool> ShowToast<TViewModel>(string message, int duration)
            where TViewModel : MvxToastViewModel;
        //public Task<bool> ShowToast<TViewModel>(string message, int duration) where TViewModel : MvxUnityViewModel;
    }
}