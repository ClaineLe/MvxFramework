using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Binding.Extensions;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Binding.Target
{
    namespace UGUI
    {
        public class MvxInputFieldTargetBinding : MvxConvertingTargetBinding, IMvxEditableTextView
        {
            protected InputField __inputField;
            protected InputField _inputField => __inputField ??= Target as InputField;
            public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
            public override Type TargetValueType => typeof(string);

            public string CurrentText => _inputField?.text;

            private string _eventName;

            public MvxInputFieldTargetBinding(InputField target, string eventName) : base(target)
            {
                if (_inputField == null)
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

            protected override bool ShouldSkipSetValueForViewSpecificReasons(object target, object value)
                => this.ShouldSkipSetValueAsHaveNearlyIdenticalNumericText(target, value);

            private void HandleValueChanged(string context)
            {
                if (_inputField == null)
                    return;
                FireValueChanged(_inputField.text);
            }

            protected override void SetValueImpl(object target, object value)
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
}