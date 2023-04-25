using System;
using System.IO;
using MvvmCross;
using MvvmCross.Exceptions;
using MvvmCross.Plugin.ResourceLoader;

namespace MvxFramework.UnityEngine.Plugins.ResourceLoader
{
    [Preserve(AllMembers = true)]
    public class MvxUnityResourceLoader : MvxResourceLoader
    {
        public override void GetResourceStream(string resourcePath, Action<Stream> streamAction)
        {
            if (!System.IO.File.Exists(resourcePath))
            {
                throw new MvxException("Failed to read file {0}", resourcePath);
            }

            using (var fileStream = System.IO.File.Open(resourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                streamAction?.Invoke(fileStream);
            }
        }
    }
}