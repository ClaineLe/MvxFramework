using System;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;

namespace MvxFramework.UnityEngine.ViewModels
{
    public abstract class MvxMessengerViewModel : MvxDisposableViewModel
    {
        private Lazy<IMvxMessenger> _messenger => new(() => Mvx.Resolve<IMvxMessenger>());

        protected MvxMessengerViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(
            logFactory, navigationService)
        {
        }

        public void Publish(MvxMessage message)
        {
            _messenger.Value.Publish(message);
        }

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