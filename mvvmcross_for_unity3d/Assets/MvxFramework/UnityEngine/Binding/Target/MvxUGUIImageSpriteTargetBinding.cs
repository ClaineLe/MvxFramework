using System;
using Microsoft.Extensions.Logging;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Logging;
using UnityEngine;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Binding.Target
{
    public class MvxUGUIImageSpriteTargetBinding : MvxConvertingTargetBinding
    {
        public MvxUGUIImageSpriteTargetBinding(Image image) : base(image)
        {
        }

        public override Type TargetValueType => typeof(Sprite);
        
        protected override void SetValueImpl(object target, object value)
        { 
            var image = (Image)target;

            try
            {
                if (TryGetSprite(value, out var sprite) == false)
                    return;
                image.sprite = sprite;
            }
            catch (Exception ex)
            {
                MvxLogHost.GetLog<MvxUGUIImageSpriteTargetBinding>()?
                    .Log(LogLevel.Error, ex, "Failed to set bitmap on ImageView");
                throw;
            }
        }

        protected bool TryGetSprite(object value, out Sprite sprite)
        {
            string assetPath = $"Icon/{value}";
            MvxLogHost.GetLog<MvxUGUIImageSpriteTargetBinding>()?
                .LogInformation($"assetPath:{assetPath}");
            sprite = Resources.Load<Sprite>(assetPath);
            return sprite != null;
        }
    }
}