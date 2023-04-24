using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.ViewModels;

namespace MvxFramework.UnityEngine.Services
{
    public class MvxToastService : IMvxToastService
    {
        private IMvxNavigationService _navigationService;

        private IMvxNavigationService navigationService =>
            _navigationService ??= Mvx.IoCProvider.Resolve<IMvxNavigationService>();

        public async Task<bool> ShowToast<TViewModel>(string message, int duration)
            where TViewModel : MvxUnityViewModel
        {
            var result = await navigationService.Navigate<TViewModel>();
            return result;
        }
    }
}