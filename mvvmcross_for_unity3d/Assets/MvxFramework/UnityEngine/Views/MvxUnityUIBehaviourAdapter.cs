using System;
using MvvmCross.Views;
using MvxFramework.UnityEngine.Views.Base;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityUIBehaviourAdapter : MvxBaseUnityUIBehaviourAdapter
    {
        protected IMvxUnityView UnityView => base.ViewController as IMvxUnityView;

        public MvxUnityUIBehaviourAdapter(IMvxEventSourceUnityUIBehaviour eventSource)
            : base(eventSource)
        {
            if (eventSource is not IMvxUnityView)
                throw new ArgumentException("eventSource", "eventSource should be a IMvxUnityView");
        }

        public override void HandleViewDidLoadCalled(object sender, EventArgs e)
        {
            UnityView.OnViewCreate();
            base.HandleViewDidLoadCalled(sender, e);
        }

        public override void HandleDisposeCalled(object sender, EventArgs e)
        {
            UnityView.OnViewDestroy();
            base.HandleDisposeCalled(sender, e);
        }
    }
}