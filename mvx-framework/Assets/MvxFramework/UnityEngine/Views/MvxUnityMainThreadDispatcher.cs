using System;
using System.Threading;
using MvvmCross.Base;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityMainThreadDispatcher : MvxMainThreadAsyncDispatcher
    {
        protected SynchronizationContext unitySynchronizationContext;
        public override bool IsOnMainThread => unitySynchronizationContext == SynchronizationContext.Current;

        public MvxUnityMainThreadDispatcher(SynchronizationContext unitySynchronizationContext)
        {
            this.unitySynchronizationContext = unitySynchronizationContext;
        }

        public override bool RequestMainThreadAction(Action action, bool maskExceptions = true)
        {
            if (IsOnMainThread)
                ExceptionMaskedAction(action, maskExceptions);
            else
                unitySynchronizationContext.Post(ignored => { ExceptionMaskedAction(action, maskExceptions); }, null);
            return true;
        }
    }
}