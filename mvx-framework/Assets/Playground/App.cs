using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Localization;
using MvvmCross.Navigation;
using MvvmCross.Plugin.JsonLocalization;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Services;
using Playground.ViewModels;
using UnityEngine.Services.LocalizeService;

namespace Playground
{
    public class App : MvxApplication
    {
        private const string GeneralNamespace = "Playground";

        public override void Initialize()
        {
            /*
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            */

            var iocProvider = Mvx.IoCProvider;

            iocProvider.RegisterSingleton<IMvxToastService>(new MvxToastService());
            iocProvider.RegisterSingleton<IMvxDialogService>(new MvxDialogService());
            iocProvider.RegisterSingleton<IMvxLoadingService>(new MvxLoadingService());


            this.InitializeLocalizeService(iocProvider);

            this.InitializeText(iocProvider);

            RegisterAppStart<SplashScreeWindowModel>();
        }

        private void InitializeLocalizeService(IMvxIoCProvider iocProvider)
        {
            var localizeSvr = new MvxLocalizeService(GeneralNamespace);
            localizeSvr.RegisterLanguage(LANG.en_GB);
            localizeSvr.RegisterLanguage(LANG.zh_CN);
            iocProvider.RegisterSingleton<IMvxLocalizeService>(localizeSvr);
        }

        private void InitializeText(IMvxIoCProvider iocProvider)
        {
            var rootFolderForResources = "Assets/Resources/Text";
            var builder = new TextProviderBuilder(GeneralNamespace, rootFolderForResources);
            iocProvider.RegisterSingleton<IMvxTextProviderBuilder>(builder);
            iocProvider.RegisterSingleton<IMvxTextProvider>(builder.TextProvider);
        }
    }
}