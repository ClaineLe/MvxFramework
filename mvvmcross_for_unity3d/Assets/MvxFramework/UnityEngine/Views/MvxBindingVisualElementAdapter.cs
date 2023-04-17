using System;
using Microsoft.Extensions.Logging;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Logging;
using MvxFramework.UnityEngine.Views.Base;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxBindingVisualElementAdapter : MvxBaseVisualElementAdapter
    {
        protected IMvxUnityView UnityView => VisualElement as IMvxUnityView;

        public MvxBindingVisualElementAdapter(IMvxEventSourceVisualElement eventSource)
            : base(eventSource)
        {
            if (eventSource is not IMvxUnityView)
                throw new ArgumentException("eventSource", "eventSource should be a IMvxUnityView");

            UnityView.BindingContext = new MvxBindingContext();
        }

        public override void HandleDisposeCalled(object sender, EventArgs e)
        {
            if (UnityView == null)
            {
                MvxLogHost.Default?.LogWarning("UnityView is null for clearup of bindings in type {0}",
                    UnityView.GetType().Name);
                return;
            }
            UnityView.ClearAllBindings();
            base.HandleDisposeCalled(sender, e);
        }
    }
}