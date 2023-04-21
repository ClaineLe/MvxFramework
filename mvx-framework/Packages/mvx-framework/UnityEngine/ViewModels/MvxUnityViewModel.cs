using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Localization;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using UnityEngine.Messages;
using UnityEngine.Services.LocalizeService;

namespace MvxFramework.UnityEngine.ViewModels
{
    public abstract class MvxUnityViewModel : MvxMessengerViewModel, IMvxUnityViewModel
    {
        protected ILogger log => MvxLogHost.GetLog(this.GetType().Name);

        private IMvxLocalizeService localizeSvr => Mvx.IoCProvider.Resolve<IMvxLocalizeService>();

        public IMvxLanguageBinder TextSource => localizeSvr.GetLanguageBinder();

        public MvxUnityViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory,
            navigationService)
        {
            Subscribe<LanguageChangedMessage>(msg => RaisePropertyChanged(() => TextSource));
        }

        public void CloseSelf()
        {
            this.NavigationService.Close(this);
        }
    }
}