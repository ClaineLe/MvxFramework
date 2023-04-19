using System;
using System.IO;
using MvvmCross.Exceptions;

namespace MvvmCross.Plugin.ResourceLoader.Platforms.UnityEngine
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