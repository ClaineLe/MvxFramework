using System.Threading;
using MvvmCross.Core;

namespace MvxFramework.UnityEngine.Core
{
    public class MvxUnitySetupSingleton : MvxSetupSingleton
    {
        public static MvxUnitySetupSingleton EnsureSingletonAvailable(
            SynchronizationContext unitySynchronizationContext)
        {
            var instance = EnsureSingletonAvailable<MvxUnitySetupSingleton>();
            instance.PlatformSetup<MvxUnitySetup>()?.PlatformInitialize(unitySynchronizationContext);
            return instance;
        }
    }
}