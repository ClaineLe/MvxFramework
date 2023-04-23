using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Commands;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Binding.Target
{
    namespace UGUI
    {
        public class MvxButtonTargetBinding : MvxTargetBinding
        {
            private Button __button;
            private Button _button => __button ??= Target as Button;
            private IMvxCommand _command;
            private string _eventName;

            public MvxButtonTargetBinding(object target, string eventName) : base(target)
            {
                if (_button == null)
                {
                    MvxBindingLog.Error("Error - UITextField is null in MvxUITextFieldTextTargetBinding");
                    return;
                }

                _eventName = eventName;
                switch (eventName)
                {
                    case MvxUGUIPropertyBinding.Button_onClick:
                    {
                        _button.onClick.AddListener(controlEvent);
                        break;
                    }
                }
            }

            public override Type TargetValueType => typeof(IMvxCommand);
            public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

            public override void SetValue(object value)
            {
                _command = value as IMvxCommand;
                if (_button == null)
                    return;
                _button.enabled = _command?.CanExecute(null) ?? false;
            }

            private void controlEvent()
            {
                if (_command == null)
                    return;

                if (!_command.CanExecute(null))
                    return;

                _command.Execute(null);
            }

            protected override void Dispose(bool isDisposing)
            {
                if (isDisposing)
                {
                    switch (_eventName)
                    {
                        case MvxUGUIPropertyBinding.Button_onClick:
                        {
                            _button.onClick.RemoveListener(controlEvent);
                            break;
                        }
                    }
                }

                base.Dispose(isDisposing);
            }
        }
    }
}