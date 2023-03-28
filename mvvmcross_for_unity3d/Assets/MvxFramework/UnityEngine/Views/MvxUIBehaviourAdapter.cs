using System;
using MvvmCross.Views;
using MvxFramework.UnityEngine.Views.Base;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUIBehaviourAdapter : MvxBaseUIBehaviourAdapter
    {
        protected IMvxUnityView unityView => ViewController as IMvxUnityView;

        public MvxUIBehaviourAdapter(IMvxEventSourceUIBehaviour eventSource) : base(eventSource)
        {
            if (eventSource is not IMvxUnityView)
                throw new ArgumentException("eventSource", "eventSource should be a IMvxUnityView");
        }
        
        public override void EventSourceOnAwakeCalled(object sender, EventArgs e)
        {
            //unityView.OnViewCreate();
            base.EventSourceOnAwakeCalled(sender, e);
        }

        public override void EventSourceOnStartCalled(object sender, EventArgs e)
        {
            //unityView.OnViewCreate();
            base.EventSourceOnStartCalled(sender, e);
        }

        public override void EventSourceOnDestroyCalled(object sender, EventArgs e)
        {
            unityView.OnViewDestroy();
            base.EventSourceOnDestroyCalled(sender, e);
        }
    }
}