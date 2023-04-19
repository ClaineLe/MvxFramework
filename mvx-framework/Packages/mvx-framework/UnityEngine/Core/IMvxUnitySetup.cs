using System.Threading;
using MvvmCross.Core;

namespace MvxFramework.UnityEngine.Core
{
    public interface IMvxUnitySetup : IMvxSetup
    {
        void PlatformInitialize(SynchronizationContext synchronizationContext);
    }
}