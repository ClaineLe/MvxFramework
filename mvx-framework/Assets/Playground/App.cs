using MvvmCross.IoC;
using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;

namespace Playground
{
    public class App : MvxUnityAppApplication<SplashScreeWindowModel>
    {
        protected override void GamePlayService(IMvxIoCProvider iocProvider)
        {
            
        }
    }
}