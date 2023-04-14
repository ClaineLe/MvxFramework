using System;
using MvvmCross.Base;

namespace MvxFramework.UnityEngine.Views.Base
{
    public class MvxBaseUnityUIBehaviourAdapter
    {
        private readonly IMvxEventSourceUnityUIBehaviour _eventSource;

        protected MvxUnityUIBehaviour ViewController
        {
            get { return _eventSource as MvxUnityUIBehaviour; }
        }

        public MvxBaseUnityUIBehaviourAdapter(IMvxEventSourceUnityUIBehaviour eventSource)
        {
            if (eventSource == null)
                throw new ArgumentException("eventSource - eventSource should not be null");

            if (!(eventSource is MvxUnityUIBehaviour))
                throw new ArgumentException("eventSource - eventSource should be a UIBehaviour");

            _eventSource = eventSource;
            _eventSource.ViewDidAppearCalled += HandleViewDidAppearCalled;
            _eventSource.ViewDidDisappearCalled += HandleViewDidDisappearCalled;
            _eventSource.ViewWillAppearCalled += HandleViewWillAppearCalled;
            _eventSource.ViewWillDisappearCalled += HandleViewWillDisappearCalled;
            _eventSource.DisposeCalled += HandleDisposeCalled;
            _eventSource.ViewDidLoadCalled += HandleViewDidLoadCalled;
        }

        public virtual void HandleViewDidLoadCalled(object sender, EventArgs e)
        {
        }

        public virtual void HandleDisposeCalled(object sender, EventArgs e)
        {
        }

        public virtual void HandleViewWillDisappearCalled(object sender, MvxValueEventArgs<bool> e)
        {
        }

        public virtual void HandleViewWillAppearCalled(object sender, MvxValueEventArgs<bool> e)
        {
        }

        public virtual void HandleViewDidDisappearCalled(object sender, MvxValueEventArgs<bool> e)
        {
        }

        public virtual void HandleViewDidAppearCalled(object sender, MvxValueEventArgs<bool> e)
        {
        }

    }
}