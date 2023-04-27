using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Localization;
using MvvmCross.Plugin.JsonLocalization;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Services;
using MvxFramework.UnityEngine.ViewModels;
using UnityEngine.Services.LocalizeService;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityAppApplication<TAppStartViewModel> : MvxApplication
        where TAppStartViewModel : MvxUnityViewModel
    {
        protected virtual string generalNamespace => "Playground";
        protected virtual string rootFolderForResources => "Text";
        
        public override void Initialize()
        {
            /*
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            */

            var iocProvider = Mvx.IoCProvider;
            BuildInService(iocProvider);
            GamePlayService(iocProvider);
            RegisterAppStart<TAppStartViewModel>();
        }
        
        protected virtual void BuildInService(IMvxIoCProvider iocProvider)
        {
            this.InitializeLocalizeService(iocProvider);
            this.InitializeText(iocProvider);
        }

        protected abstract void GamePlayService(IMvxIoCProvider iocProvider);

        private void InitializeLocalizeService(IMvxIoCProvider iocProvider)
        {
            var localizeSvr = new MvxLocalizeService(generalNamespace);
            localizeSvr.RegisterLanguage(LANG.en_GB);
            localizeSvr.RegisterLanguage(LANG.zh_CN);
            iocProvider.RegisterSingleton<IMvxLocalizeService>(localizeSvr);
        }

        private void InitializeText(IMvxIoCProvider iocProvider)
        {
            var builder = new TextProviderBuilder(generalNamespace, rootFolderForResources);
            iocProvider.RegisterSingleton<IMvxTextProviderBuilder>(builder);
            iocProvider.RegisterSingleton<IMvxTextProvider>(builder.TextProvider);
        }
    }
}