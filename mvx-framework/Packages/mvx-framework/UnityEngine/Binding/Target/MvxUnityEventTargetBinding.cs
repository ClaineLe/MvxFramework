using System;
using MvvmCross.Commands;
using UnityEngine.EventSystems;
using MvvmCross.WeakSubscription;

namespace MvxFramework.UnityEngine.Binding.Target
{
    public abstract class MvxUnityEventTargetBinding<TBehaviour> : MvxUnityEventBaseTargetBinding<TBehaviour>
        where TBehaviour : UIBehaviour
    {
        private IMvxCommand _command;

        public override Type TargetValueType => typeof(IMvxCommand);

        protected MvxUnityEventTargetBinding(TBehaviour control, string controlEvent) : base(control, controlEvent)
        {
        }

        protected override void OnSetValueImpl(object value)
        {
            _command = value as IMvxCommand;
            if (_command != null)
            {
                _canExecuteSubscription = _command.WeakSubscribe(_canExecuteEventHandler);
            }
        }

        protected override void RefreshEnabledState()
        {
            var view = Control;
            if (view == null) return;

            view.enabled = _command?.CanExecute(null) ?? true;
        }

        protected void ControlEvent()
        {
            if (_command == null) return;

            if (!_command.CanExecute(null)) return;

            _command.Execute(null);
        }
    }

    public abstract class MvxUnityEventTargetBinding<TBehaviour, TParameter> : MvxUnityEventBaseTargetBinding<TBehaviour>
        where TBehaviour : UIBehaviour
    {
        private IMvxCommand<TParameter> _command;

        public override Type TargetValueType => typeof(IMvxCommand<TParameter>);

        protected void ControlEvent(TParameter parameter)
        {
            if (_command == null) return;

            if (!_command.CanExecute(parameter)) return;

            _command.Execute(parameter);
        }

        protected override void OnSetValueImpl(object value)
        {
            _command = value as IMvxCommand<TParameter>;
            if (_command != null)
            {
                _canExecuteSubscription = _command.WeakSubscribe(_canExecuteEventHandler);
            }
        }

        protected override void RefreshEnabledState()
        {
            var view = Control;
            if (view == null) return;

            view.enabled = _command?.CanExecute(default) ?? true;
        }

        protected MvxUnityEventTargetBinding(TBehaviour control, string controlEvent) : base(control, controlEvent)
        {
        }
    }
}