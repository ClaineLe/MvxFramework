using System;
using MvvmCross.Base;

namespace MvxFramework.UnityEngine.Views.Base
{
    public class MvxEventSourceVisualElement : MvxVisualElement, IMvxEventSourceVisualElement
    {
        public event EventHandler ViewDidLoadCalled;
        public event EventHandler<MvxValueEventArgs<bool>> ViewWillAppearCalled;
        public event EventHandler<MvxValueEventArgs<bool>> ViewDidAppearCalled;
        public event EventHandler<MvxValueEventArgs<bool>> ViewDidDisappearCalled;
        public event EventHandler<MvxValueEventArgs<bool>> ViewWillDisappearCalled;
        public event EventHandler DisposeCalled;

        protected override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ViewDidLoadCalled.Raise(this);
        }
        
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            ViewWillDisappearCalled.Raise(this, animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            ViewDidAppearCalled.Raise(this, animated);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            ViewWillAppearCalled.Raise(this, animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            ViewDidDisappearCalled.Raise(this, animated);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeCalled.Raise(this);
            }
            base.Dispose(disposing);
        }
    }
}