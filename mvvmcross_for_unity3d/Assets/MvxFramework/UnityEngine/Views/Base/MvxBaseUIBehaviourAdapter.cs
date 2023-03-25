using System;
using UnityEngine.EventSystems;

namespace MvxFramework.UnityEngine.Views.Base
{
    public class MvxBaseUIBehaviourAdapter
    {
        private readonly IMvxEventSourceUIBehaviour _eventSource;

        protected UIBehaviour ViewController => _eventSource as UIBehaviour;

        public MvxBaseUIBehaviourAdapter(IMvxEventSourceUIBehaviour eventSource)
        {
            if (eventSource == null)
                throw new ArgumentException("eventSource - eventSource should not be null");

            if (eventSource is not UIBehaviour)
                throw new ArgumentException("eventSource - eventSource should be a UIViewController");

            _eventSource = eventSource;

            _eventSource.ViewAwakeCalled += EventSourceOnAwakeCalled;
            _eventSource.ViewEnableCalled += EventSourceOnEnableCalled;
            _eventSource.ViewStartCalled += EventSourceOnStartCalled;
            _eventSource.ViewDisableCalled += EventSourceOnDisableCalled;
            _eventSource.ViewDestroyCalled += EventSourceOnDestroyCalled;
        }

        public virtual void EventSourceOnAwakeCalled(object sender, EventArgs e)
        {
        }

        public virtual void EventSourceOnEnableCalled(object sender, EventArgs e)
        {
        }

        public virtual void EventSourceOnStartCalled(object sender, EventArgs e)
        {
        }

        public virtual void EventSourceOnDisableCalled(object sender, EventArgs e)
        {
        }

        public virtual void EventSourceOnDestroyCalled(object sender, EventArgs e)
        {
        }
    }
}