using System;
using MvvmCross.Base;

namespace MvxFramework.UnityEngine.Views.Base
{
    public interface IMvxEventSourceUnityUIBehaviour : IMvxDisposeSource
    {
        event EventHandler ViewDidLoadCalled;
        event EventHandler<MvxValueEventArgs<bool>> ViewWillAppearCalled;
        event EventHandler<MvxValueEventArgs<bool>> ViewDidAppearCalled;
        event EventHandler<MvxValueEventArgs<bool>> ViewDidDisappearCalled;
        event EventHandler<MvxValueEventArgs<bool>> ViewWillDisappearCalled;
    }
}