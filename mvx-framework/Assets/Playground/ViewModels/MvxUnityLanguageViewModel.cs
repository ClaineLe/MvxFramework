using Microsoft.Extensions.Logging;
using MvvmCross.Localization;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.ViewModels;
using Playground.Core;

namespace Playground.ViewModels
{
    public abstract class MvxUnityLanguageViewModel : MvxUnityViewModel
    {
        public IMvxLanguageBinder TextSource => new MvxLanguageBinder(Constants.GeneralNamespace, GetType().Name);

        protected MvxUnityLanguageViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }
    }
}