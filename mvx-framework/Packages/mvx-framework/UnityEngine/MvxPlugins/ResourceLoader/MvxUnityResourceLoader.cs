using System;
using System.IO;
using MvvmCross;
using MvvmCross.Exceptions;
using MvvmCross.Plugin.ResourceLoader;
using UnityEngine;

namespace MvxFramework.UnityEngine.Plugins.ResourceLoader
{
    [Preserve(AllMembers = true)]
    public class MvxUnityResourceLoader : MvxResourceLoader
    {
        public override void GetResourceStream(string resourcePath, Action<Stream> streamAction)
        {
            var textAsset = Resources.Load<TextAsset>(resourcePath);
            if (textAsset == null)
            {
                throw new MvxException("Failed to read file {0}", resourcePath);
            }

            using (var memStream = new MemoryStream(textAsset.bytes))
            {
                streamAction?.Invoke(memStream);
            }
        }
    }
}