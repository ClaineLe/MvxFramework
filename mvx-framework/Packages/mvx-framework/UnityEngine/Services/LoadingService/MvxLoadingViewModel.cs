using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.ViewModels;

namespace MvxFramework.UnityEngine.Services
{
    public class LoadingParameter
    {
    }
    
    public abstract class MvxLoadingViewModel : MvxUnityViewModel<LoadingParameter>
    {
        public abstract float ProgressValue { get; set; }
        public abstract string Content { get; set; }

        protected MvxLoadingViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }
    }
}