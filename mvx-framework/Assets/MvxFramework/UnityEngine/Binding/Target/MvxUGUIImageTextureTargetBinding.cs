using System;
using Microsoft.Extensions.Logging;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Logging;
using UnityEngine;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Binding.Target
{
    public class MvxUGUIImageTextureTargetBinding : MvxConvertingTargetBinding
    {
        public MvxUGUIImageTextureTargetBinding(RawImage rawImage) : base(rawImage)
        {
        }

        public override Type TargetValueType => typeof(Texture);
        
        protected override void SetValueImpl(object target, object value)
        { 
            var rawImage = (RawImage)target;

            try
            {
                if (TryGetTexture(value, out var texture) == false)
                    return;
                rawImage.texture = texture;
            }
            catch (Exception ex)
            {
                MvxLogHost.GetLog<MvxUGUIImageTextureTargetBinding>()?
                    .Log(LogLevel.Error, ex, "Failed to set bitmap on ImageView");
                throw;
            }
        }

        protected bool TryGetTexture(object value, out Texture sprite)
        {
            string assetPath = $"Icon/{value}";
            //MvxLogHost.GetLog<MvxUGUIImageTextureTargetBinding>()?.LogInformation($"assetPath:{assetPath}");
            sprite = Resources.Load<Texture>(assetPath);
            return sprite != null;
        }
    }
}