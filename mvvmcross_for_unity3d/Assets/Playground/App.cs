using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Localization;
using MvvmCross.Plugin.JsonLocalization;
using MvvmCross.ViewModels;
using Playground.Core.Services;
using Playground.ViewModels;

namespace Playground
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            InitializeText();
            RegisterAppStart<SplashScreeViewModel>();
        }
        
        
        private void InitializeText()
        {
            var builder = new TextProviderBuilder();
            Mvx.IoCProvider?.RegisterSingleton<IMvxTextProviderBuilder>(builder);
            Mvx.IoCProvider?.RegisterSingleton<IMvxTextProvider>(builder.TextProvider);
        }
    }
}