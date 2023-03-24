using System;

namespace MvxFramework.UnityEngine.Views.Base
{
    public interface IMvxEventSourceUIBehaviour
    {
        event EventHandler ViewAwakeCalled;
        event EventHandler ViewEnableCalled;
        event EventHandler ViewStartCalled;
        event EventHandler ViewDisableCalled;
        event EventHandler ViewDestroyCalled;
    }
}