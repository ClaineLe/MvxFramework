using System;
using Microsoft.Extensions.Logging;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Logging;
using UnityEngine;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Binding.Target
{
    namespace UGUI
    {
        public class MvxRawImageTargetBinding : MvxTargetBinding
        {
            private RawImage __rawImage;
            private RawImage _rawImage => __rawImage ??= Target as RawImage; 

            public override Type TargetValueType => typeof(Texture);
            public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;
            
            public MvxRawImageTargetBinding(RawImage rawImage) : base(rawImage)
            {
            }

            public override void SetValue(object value)
            {
                try
                {
                    if (TryGetTexture(value, out var texture) == false)
                        return;
                    _rawImage.texture = texture;
                }
                catch (Exception ex)
                {
                    MvxLogHost.GetLog<MvxRawImageTargetBinding>()?
                        .Log(LogLevel.Error, ex, "Failed to set bitmap on ImageView");
                    throw;
                }
            }

            protected bool TryGetTexture(object value, out Texture sprite)
            {
                string assetPath = $"Icon/{value}";
                sprite = Resources.Load<Texture>(assetPath);
                return sprite != null;
            }
        }
    }
}