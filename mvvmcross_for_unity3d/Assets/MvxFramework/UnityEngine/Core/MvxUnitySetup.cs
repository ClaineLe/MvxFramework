using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Microsoft.Extensions.Logging;
using MvvmCross.Core;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using MvxFramework.UnityEngine.Logging;
using MvxFramework.UnityEngine.Presenters;
using MvxFramework.UnityEngine.Views;

namespace MvxFramework.UnityEngine.Core
{
#nullable enable
    public abstract class MvxUnitySetup : MvxSetup, IMvxUnitySetup
    {
        protected SynchronizationContext unitySynchronizationContext;

        private IMvxUnityViewPresenter? _presenter;

        protected IMvxUnityViewPresenter Presenter => _presenter ??= CreateViewPresenter();
        
        public void PlatformInitialize(SynchronizationContext synchronizationContext)
        {
            this.unitySynchronizationContext = synchronizationContext;
        }

        protected override ILoggerFactory? CreateLogFactory()
            => new MvxUnityLoggerFactory();

        protected override ILoggerProvider? CreateLogProvider()
            => new MvxUnityLoggerProvider();
        
        protected override IMvxNameMapping CreateViewToViewModelNaming()
            => new MvxPostfixAwareViewToViewModelNameMapping("View", "Window");

        protected virtual IMvxUnityViewPresenter CreateViewPresenter()
            => new MvxUnityViewPresenter();
        
        protected override IMvxViewDispatcher CreateViewDispatcher()
            => new MvxUnityViewDispatcher(Presenter, unitySynchronizationContext);

        protected override IMvxViewsContainer CreateViewsContainer(IMvxIoCProvider iocProvider)
        {
            var container = new MvxUnityViewsContainer();
            RegisterUnityViewCreator(iocProvider, container);
            return container;
        }
        protected virtual void RegisterUnityViewCreator(IMvxIoCProvider iocProvider, IMvxUnityViewsContainer container)
        {
            ValidateArguments(iocProvider);
            iocProvider.RegisterSingleton<IMvxUnityViewCreator>(container);
            //iocProvider.RegisterSingleton<IMvxCurrentRequest>(container);
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