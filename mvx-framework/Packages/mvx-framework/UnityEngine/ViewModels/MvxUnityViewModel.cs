using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Localization;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using UnityEngine.Services.LocalizeService;

namespace MvxFramework.UnityEngine.ViewModels
{
    public abstract class MvxUnityViewModel : MvxViewModel, IMvxUnityViewModel
    {
        private ILogger? _log;

        protected virtual IMvxNavigationService NavigationService { get; }

        protected virtual ILoggerFactory LoggerFactory { get; }

        protected virtual ILogger log => _log ??= LoggerFactory.CreateLogger(GetType().Name);


        private IMvxLocalizeService localizeSvr => Mvx.IoCProvider.Resolve<IMvxLocalizeService>();

        public IMvxLanguageBinder TextSource => localizeSvr.GetLanguageBinder();

        private readonly List<IDisposable> _disposables = new List<IDisposable>();
        private Lazy<IMvxMessenger> _messenger => new(() => Mvx.Resolve<IMvxMessenger>());

        public MvxUnityViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService)
        {
            LoggerFactory = logFactory;
            NavigationService = navigationService;
            localizeSvr.OnChangedLanguage += OnChangedLanguage;
        }

        protected virtual void OnChangedLanguage(object sender, EventArgs args)
            => RaisePropertyChanged(() => TextSource);

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

        public void CloseSelf()
        {
            this.NavigationService.Close(this);
        }

        ~MvxUnityViewModel()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                localizeSvr.OnChangedLanguage -= OnChangedLanguage;

                foreach (var disposable in _disposables)
                    disposable.Dispose();
                _disposables.Clear();
            }
        }
    }

    public abstract class MvxUnityViewModel<TParameter> : MvxUnityViewModel, IMvxUnityViewModel<TParameter>
    {
        protected MvxUnityViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }

        public abstract void Prepare(TParameter parameter);
    }
}