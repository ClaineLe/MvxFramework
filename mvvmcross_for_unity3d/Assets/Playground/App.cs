using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Views;

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
            //Mvx.IoCProvider?.RegisterSingleton<IMvxTextProvider>(new TextProviderBuilder().TextProvider);
            //RegisterAppStart<TLoginViewModel>();
        }
    }
}