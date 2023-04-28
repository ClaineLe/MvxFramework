using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Logging;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityViewController : MvxUnityAnimationView
    {
        private ILogger _log;
        protected ILogger log => _log ??= MvxLogHost.GetLog(this.GetType().Name);
        private Lazy<IMvxMessenger> _messenger => new(() => Mvx.Resolve<IMvxMessenger>());
        
        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        protected sealed override void Awake()
        {
            this.AdaptForBinding();
            base.Awake();
        }

        public object DataContext
        {
            get => BindingContext.DataContext;
            set => BindingContext.DataContext = value;
        }

        public IMvxViewModel ViewModel
        {
            get => DataContext as IMvxViewModel;
            set => DataContext = value;
        }

        public MvxViewModelRequest Request { get; set; }

        public IMvxBindingContext BindingContext { get; set; }
        protected abstract void OnViewLoaded();

        protected sealed override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.OnViewLoaded();
            ViewModel?.ViewCreated();
        }

        public sealed override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.OnViewWillAppear();
            ViewModel?.ViewAppearing();
        }

        public sealed override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            this.OnViewDidAppear();
            ViewModel?.ViewAppeared();
        }

        public sealed override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            this.OnViewWillDisappear();
            ViewModel?.ViewDisappearing();
        }

        public sealed override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            this.OnViewDidDisappear();
            ViewModel?.ViewDisappeared();
        }

        protected sealed override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.OnDispose();
            ViewModel?.ViewDestroy();
        }
        
        
        protected virtual void OnViewWillDisappear()
        {
            log.LogInformation("OnViewWillDisappear");
        }

        protected virtual void OnViewDidAppear()
        {
            log.LogInformation("OnViewDidAppear");
        }

        protected virtual void OnViewWillAppear()
        {
            log.LogInformation("OnViewWillAppear");
        }

        protected virtual void OnViewDidDisappear()
        {
            log.LogInformation("OnViewDidDisappear");
        }

        protected virtual void OnDispose()
        {
            log.LogInformation("OnDispose");
        }
        
        protected void AddDisposable(IDisposable disposable) => _disposables.Add(disposable);

        protected void RemoveDisposable(IDisposable disposable) => _disposables.Remove(disposable);

        public void Publish(MvxMessage message) => _messenger.Value.Publish(message);

        public MvxSubscriptionToken Subscribe<TMessage>(Action<TMessage> action, string tag = null)
            where TMessage : MvxMessage
        {
            var token = _messenger.Value.Subscribe<TMessage>(action, MvxReference.Weak, tag);
            AddDisposable(token);
            return token;
        }

        public MvxSubscriptionToken SubscribeOnMainThread<TMessage>(Action<TMessage> action, string tag = null)
            where TMessage : MvxMessage
        {
            var token = _messenger.Value.SubscribeOnMainThread<TMessage>(action, MvxReference.Weak, tag);
            AddDisposable(token);
            return token;
        }

        public void Unsubscribe(MvxSubscriptionToken token)
        {
            RemoveDisposable(token);
            token.Dispose();
        }
    }
}