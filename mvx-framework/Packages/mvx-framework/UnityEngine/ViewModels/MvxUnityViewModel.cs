using System;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Localization;
using MvvmCross.Logging;
using MvvmCross.Navigation;
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
            localizeSvr.OnChangedLanguage += OnChangedLanguage;
        }

        public void CloseSelf()
        {
            this.NavigationService.Close(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                localizeSvr.OnChangedLanguage -= OnChangedLanguage;
            }
            base.Dispose(disposing);
        }
        
        
        protected virtual void OnChangedLanguage(object sender, EventArgs args)
        {
            RaisePropertyChanged(() => TextSource);
        }
    }
}