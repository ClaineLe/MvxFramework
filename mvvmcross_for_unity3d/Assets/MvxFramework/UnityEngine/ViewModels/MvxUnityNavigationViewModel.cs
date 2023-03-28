using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.ViewModels
{
    public abstract class MvxUnityNavigationViewModel : MvxNavigationViewModel, IMvxUnityViewModel
    {
        public MvxUnityNavigationViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }

        public virtual Task<bool> Show(bool animated) => Task.FromResult(true);

        public virtual Task<bool> Hide(bool animated) => Task.FromResult(true);
    }
}