using MvvmCross.Core;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Core;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityApplication : IMvxUnityApplication
    {
        public MvxUnityApplication()
        {
        }

        protected virtual void RegisterSetup()
        {
        }
    }

    public abstract class MvxUnityApplication<TMvxUnitySetup, TApplication> : MvxUnityApplication
        where TMvxUnitySetup : MvxUnitySetup<TApplication>, new()
        where TApplication : class, IMvxApplication, new()
    {
        public MvxUnityApplication() : base()
        {
        }

        protected override void RegisterSetup()
        {
            this.RegisterSetupType<TMvxUnitySetup>();
        }
    }
}