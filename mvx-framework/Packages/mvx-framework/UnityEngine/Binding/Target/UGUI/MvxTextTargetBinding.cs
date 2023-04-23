using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Binding.Target.UGUI
{
    public class MvxTextTargetBinding : MvxTargetBinding
    {
        private Text __text;
        private Text _text => __text ??= Target as Text;
        
        public MvxTextTargetBinding(object target) : base(target)
        {
        }

        public override Type TargetValueType => typeof(Text);
        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        public override void SetValue(object value)
        {
            if(_text == null)
                return;
            _text.text = value as string;
        }
    }
}