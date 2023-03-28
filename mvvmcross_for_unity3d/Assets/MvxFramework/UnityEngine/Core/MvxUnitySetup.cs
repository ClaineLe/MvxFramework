using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Microsoft.Extensions.Logging;
using MvvmCross.Binding;
using MvvmCross.Binding.Binders;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Converters;
using MvvmCross.Core;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using MvxFramework.UnityEngine.Binding;
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

        protected override void InitializeLastChance(IMvxIoCProvider iocProvider)
        {
            InitializeBindingBuilder(iocProvider);
            base.InitializeLastChance(iocProvider);
        }

        protected virtual void InitializeBindingBuilder(IMvxIoCProvider iocProvider)
        {
            RegisterBindingBuilderCallbacks(iocProvider);
            var bindingBuilder = CreateBindingBuilder();
            bindingBuilder.DoRegistration(iocProvider);
        }
        protected virtual void RegisterBindingBuilderCallbacks(IMvxIoCProvider iocProvider)
        {
            iocProvider.CallbackWhenRegistered<IMvxValueConverterRegistry>(FillValueConverters);
            iocProvider.CallbackWhenRegistered<IMvxTargetBindingFactoryRegistry>(FillTargetFactories);
            iocProvider.CallbackWhenRegistered<IMvxBindingNameRegistry>(FillBindingNames);
        }
        protected virtual MvxBindingBuilder CreateBindingBuilder()
            => new MvxUnityBindingBuilder();
        
        protected virtual void FillBindingNames(IMvxBindingNameRegistry obj)
        {
            // this base class does nothing
        }

        protected virtual void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            registry.Fill(ValueConverterAssemblies);
            registry.Fill(ValueConverterHolders);
        }
        protected virtual void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            // this base class does nothing
        }
        protected virtual IEnumerable<Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn = new List<Assembly>();
                toReturn.AddRange(GetViewModelAssemblies());
                toReturn.AddRange(GetViewAssemblies());
                return toReturn;
            }
        }
        protected virtual List<Type> ValueConverterHolders => new List<Type>();
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