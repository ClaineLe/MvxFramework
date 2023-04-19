using MvvmCross.Base;

namespace MvvmCross.Plugin.ResourceLoader.Platforms.UnityEngine
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