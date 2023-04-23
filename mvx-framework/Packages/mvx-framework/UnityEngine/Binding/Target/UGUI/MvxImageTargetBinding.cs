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
        public class MvxImageTargetBinding : MvxTargetBinding
        {
            private Image __image;
            private Image _image => __image ??= Target as Image;
            
            public MvxImageTargetBinding(Image image) : base(image)
            {
            }

            public override Type TargetValueType => typeof(Sprite);
            
            public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

            public override void SetValue(object value)
            {
                try
                {
                    if (TryGetSprite(value, out var sprite) == false)
                        return;
                    _image.sprite = sprite;
                }
                catch (Exception ex)
                {
                    MvxLogHost.GetLog<MvxImageTargetBinding>()
                        ?.Log(LogLevel.Error, ex, "Failed to set bitmap on ImageView");
                    throw;
                }
            }

            protected bool TryGetSprite(object value, out Sprite sprite)
            {
                string assetPath = $"Icon/{value}";
                //MvxLogHost.GetLog<MvxUGUIImageSpriteTargetBinding>()?.LogInformation($"assetPath:{assetPath}");
                sprite = Resources.Load<Sprite>(assetPath);
                return sprite != null;
            }
        }
    }
}