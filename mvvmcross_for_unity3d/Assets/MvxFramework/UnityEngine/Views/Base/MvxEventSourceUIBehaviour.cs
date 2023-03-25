using System;
using MvvmCross.Base;
using UnityEngine.EventSystems;

namespace MvxFramework.UnityEngine.Views.Base
{
    public class MvxEventSourceUIBehaviour : UIBehaviour, IMvxEventSourceUIBehaviour
    {
        public event EventHandler ViewAwakeCalled;
        public event EventHandler ViewEnableCalled;
        public event EventHandler ViewStartCalled;
        public event EventHandler ViewDisableCalled;
        public event EventHandler ViewDestroyCalled;

        protected override void Awake()
        {
            base.Awake();
            this.AdaptForBinding();
            ViewAwakeCalled?.Raise(this);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            ViewEnableCalled?.Raise(this);
        }

        protected override void Start()
        {
            base.Start();
            ViewStartCalled?.Raise(this);
        }

        protected override void OnDisable()
        {
            ViewDisableCalled?.Raise(this);
            base.OnDisable();
        }

        protected override void OnDestroy()
        {
            ViewDestroyCalled?.Raise(this);
            base.OnDestroy();
        }
    }
}