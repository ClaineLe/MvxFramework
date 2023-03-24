using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using MvvmCross.Core;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Core
{
#nullable enable
    public abstract class MvxUnitySetup : MvxSetup, IMvxUnitySetup
    {
        protected SynchronizationContext unitySynchronizationContext;

        public void PlatformInitialize(SynchronizationContext synchronizationContext)
        {
            this.unitySynchronizationContext = synchronizationContext;
        }
    }

    public abstract class MvxUnitySetup<TApplication> : MvxUnitySetup where TApplication : class, IMvxApplication, new()
    {
        protected override IMvxApplication CreateApp(IMvxIoCProvider iocProvider) =>
            iocProvider.IoCConstruct<TApplication>();

        public override IEnumerable<Assembly> GetViewModelAssemblies()
            => new[] { typeof(TApplication).GetTypeInfo().Assembly };
    }
#nullable restore
}