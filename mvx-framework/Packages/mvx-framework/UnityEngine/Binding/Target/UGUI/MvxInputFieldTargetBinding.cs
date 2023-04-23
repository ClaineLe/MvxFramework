using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Binding.Extensions;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Binding.Target.UGUI
{
    public class MvxInputFieldTargetBinding : MvxTargetBinding, IMvxEditableTextView
    {
        
        protected InputField __inputField;
        protected InputField _inputField => __inputField ??= Target as InputField;
        public string CurrentText => _inputField?.text;


        private string _eventName;

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
        public override Type TargetValueType => typeof(string);
        
        public MvxInputFieldTargetBinding(InputField target, string eventName) : base(target)
        { if (_inputField == null)
            {
                MvxBindingLog.Error("Error - UITextField is null in MvxUITextFieldTextTargetBinding");
                return;
            }

            _eventName = eventName;
            switch (eventName)
            {
                case MvxUGUIPropertyBinding.InputField_onEndEdit:
                {
                    _inputField.onEndEdit.AddListener(HandleValueChanged);
                    break;
                }
                case MvxUGUIPropertyBinding.InputField_onValueChanged:
                {
                    _inputField.onValueChanged.AddListener(HandleValueChanged);
                    break;
                }
            }
        }
        private void HandleValueChanged(string context)
        {
            if (_inputField == null)
                return;
            FireValueChanged(_inputField.text);
        }

        public override void SetValue(object value)
        {
            if (_inputField == null)
                return;
            _inputField.text = value as string;
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                switch (_eventName)
                {
                    case MvxUGUIPropertyBinding.InputField_onEndEdit:
                    {
                        _inputField.onEndEdit.RemoveListener(HandleValueChanged);
                        break;
                    }
                    case MvxUGUIPropertyBinding.InputField_onValueChanged:
                    {
                        _inputField.onValueChanged.RemoveListener(HandleValueChanged);
                        break;
                    }
                }
            }

            base.Dispose(isDisposing);
        }
    }
}