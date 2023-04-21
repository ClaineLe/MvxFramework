using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Localization;
using MvvmCross.Plugin.JsonLocalization;
using MvvmCross.ViewModels;
using Playground.ViewModels;
using UnityEngine.Services.LocalizeService;

namespace Playground
{
    public class App : MvxApplication
    {
        private const string GeneralNamespace = "Playground";

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            this.InitializeLocalizeService();
            this.InitializeText();
            
            RegisterAppStart<SplashScreeWindowModel>();
        }

        private void InitializeLocalizeService()
        {
            var localizeSvr = new MvxLocalizeService(GeneralNamespace);
            localizeSvr.RegisterLanguage(LANG.en_GB);
            localizeSvr.RegisterLanguage(LANG.zh_CN);
            Mvx.IoCProvider.RegisterSingleton<IMvxLocalizeService>(localizeSvr);
        }
        
        private void InitializeText()
        {
            var rootFolderForResources = "Assets/Resources/Text";
            var builder = new TextProviderBuilder(GeneralNamespace, rootFolderForResources);
            Mvx.IoCProvider.RegisterSingleton<IMvxTextProviderBuilder>(builder);
            Mvx.IoCProvider.RegisterSingleton<IMvxTextProvider>(builder.TextProvider);
        }

    }
}