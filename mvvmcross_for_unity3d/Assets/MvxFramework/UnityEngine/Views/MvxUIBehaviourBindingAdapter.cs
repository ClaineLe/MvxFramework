using System;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Logging;
using MvxFramework.UnityEngine.Views.Base;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUIBehaviourBindingAdapter : MvxBaseUIBehaviourAdapter
    {
        protected IMvxUnityView unityView => ViewController as IMvxUnityView;

        public MvxUIBehaviourBindingAdapter(IMvxEventSourceUIBehaviour eventSource) : base(eventSource)
        {
            if (eventSource is not IMvxUnityView)
                throw new ArgumentException($"{nameof(eventSource)} should be a {nameof(IMvxUnityView)}", nameof(eventSource));

            if (Mvx.IoCProvider?.TryResolve<IMvxBindingContext>(out var bindingContext) == true)
            {
                unityView.BindingContext = bindingContext;
            }
        }
        public override void EventSourceOnDestroyCalled(object sender, EventArgs e)
        {
            if (unityView == null)
            {
                MvxLogHost.GetLog<MvxUIBehaviourBindingAdapter>()?.LogWarning(
                    "{IosView} is null for clear-up of bindings", nameof(unityView));
                return;
            }
            unityView.ClearAllBindings();
            base.EventSourceOnDestroyCalled(sender, e);
        }
    }
}