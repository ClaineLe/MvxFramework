using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Plugin;


namespace MvxFramework.UnityEngine.Plugins.ResourceLoader
{
    [MvxPlugin]
    [Preserve(AllMembers = true)]
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.IoCProvider?.RegisterType<IMvxResourceLoader, MvxUnityResourceLoader>();
        }
    }
}