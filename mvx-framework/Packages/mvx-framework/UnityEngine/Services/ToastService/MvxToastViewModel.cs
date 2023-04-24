using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.ViewModels;

namespace MvxFramework.UnityEngine.Services
{
    public class MvxToastViewModel : MvxUnityViewModel<ToastParameter>
    {
        protected ToastParameter parameter;
        public MvxToastViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }

        public override void Prepare(ToastParameter parameter)
        {
            this.parameter = parameter;
        }
    }
}