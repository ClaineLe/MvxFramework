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
            protected InputField View => Target as InputField;
            public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
            public override Type TargetValueType => typeof(string);

            public string CurrentText => View?.text;

            private string _eventName;

            public MvxInputFieldTargetBinding(InputField target, string eventName) : base(target)
            {
                if (View == null)
                {
                    MvxBindingLog.Error("Error - UITextField is null in MvxUITextFieldTextTargetBinding");
                    return;
                }

                _eventName = eventName;
                switch (eventName)
                {
                    case MvxUGUIPropertyBinding.InputField_onEndEdit:
                    {
                        View.onEndEdit.AddListener(HandleValueChanged);
                        break;
                    }
                    case MvxUGUIPropertyBinding.InputField_onValueChanged:
                    {
                        View.onValueChanged.AddListener(HandleValueChanged);
                        break;
                    }
                }
            }

            protected override bool ShouldSkipSetValueForViewSpecificReasons(object target, object value)
                => this.ShouldSkipSetValueAsHaveNearlyIdenticalNumericText(target, value);

            private void HandleValueChanged(string context)
            {
                var view = View;
                if (view == null)
                    return;
                FireValueChanged(view.text);
            }

            protected override void SetValueImpl(object target, object value)
            {
                var view = target as InputField;
                if (view == null)
                    return;
                view.text = value as string;
            }

            protected override void Dispose(bool isDisposing)
            {
                if (isDisposing)
                {
                    switch (_eventName)
                    {
                        case MvxUGUIPropertyBinding.InputField_onEndEdit:
                        {
                            View.onEndEdit.RemoveListener(HandleValueChanged);
                            break;
                        }
                        case MvxUGUIPropertyBinding.InputField_onValueChanged:
                        {
                            View.onValueChanged.RemoveListener(HandleValueChanged);
                            break;
                        }
                    }
                }

                base.Dispose(isDisposing);
            }
        }
    }
}