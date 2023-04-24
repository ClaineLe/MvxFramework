using System.Threading.Tasks;
using MvxFramework.UnityEngine.ViewModels;

namespace MvxFramework.UnityEngine.Services
{
    public interface IMvxToastService
    {
        public Task<bool> ShowToast<TViewModel>(string message, int duration) where TViewModel : MvxUnityViewModel;
    }
}