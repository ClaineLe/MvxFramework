using System;
using System.Windows.Input;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.WeakSubscription;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Binding.Target
{
    public class MvxUGUIButtonTargetBinding : MvxConvertingTargetBinding
    {
        private ICommand _command;
        private IDisposable _canExecuteSubscription;
        private IDisposable _controlEventSubscription;

        private readonly string _controlEvent;
        private readonly EventHandler<EventArgs> _canExecuteEventHandler;

        protected Button Control => Target as Button;

        public MvxUGUIButtonTargetBinding(Button control, string controlEvent)
            : base(control)
        {
            _controlEvent = controlEvent;

            if (control == null)
            {
                MvxBindingLog.Error("Error - UIControl is null in MvxUIControlTargetBinding");
            }
            else
            {
                AddHandler(control);
            }

            _canExecuteEventHandler = new EventHandler<EventArgs>(OnCanExecuteChanged);
        }

        private void ControlEvent()
        {
            if (_command == null) return;

            if (!_command.CanExecute(null)) return;

            _command.Execute(null);
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        public override Type TargetValueType => typeof(ICommand);

        protected override void SetValueImpl(object target, object value)
        {
            _canExecuteSubscription?.Dispose();
            _canExecuteSubscription = null;

            _command = value as ICommand;
            if (_command != null)
            {
                _canExecuteSubscription = _command.WeakSubscribe(_canExecuteEventHandler);
            }

            RefreshEnabledState();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                RemoveHandler();
                _canExecuteSubscription?.Dispose();
                _canExecuteSubscription = null;
            }

            base.Dispose(isDisposing);
        }

        private void RefreshEnabledState()
        {
            var view = Control;
            if (view == null) return;

            view.enabled = _command?.CanExecute(null) ?? false;
        }

        private void OnCanExecuteChanged(object sender, EventArgs e)
        {
            RefreshEnabledState();
        }

        private void AddHandler(Button control)
        {
            switch (_controlEvent)
            {
                //case MvxIosPropertyBinding.UIControl_TouchDown:
                //    _controlEventSubscription = control.WeakSubscribe(nameof(control.TouchDown), ControlEvent);
                //    break;
                case "onClick":
                    control.onClick.AddListener(ControlEvent);
                    //_controlEventSubscription = control.WeakSubscribe("onClick", ControlEvent);
                    break;
                
                default:
                    MvxBindingLog.Error("Error - Invalid controlEvent in MvxUIControlTargetBinding");
                    break;
            }
        }

        private void RemoveHandler()
        {
            switch (_controlEvent)
            {
                case "onClick":
                    //_controlEventSubscription?.Dispose();
                    Control.onClick.RemoveListener(ControlEvent);
                    break;
                default:
                    MvxBindingLog.Error("Error - Invalid controlEvent in MvxUIControlTargetBinding");
                    break;
            }
        }
    }
}