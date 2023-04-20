using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using UnityEngine.EventSystems;

namespace MvxFramework.UnityEngine.Binding.Target
{
    public abstract class MvxUnityEventBaseTargetBinding<TBehaviour> : MvxConvertingTargetBinding
        where TBehaviour : UIBehaviour
    {
        protected readonly string _controlEvent;
        protected IDisposable _canExecuteSubscription;
        protected TBehaviour Control => Target as TBehaviour;

        protected abstract void AddHandler(TBehaviour control);
        protected abstract void RemoveHandler();
        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;
        protected readonly EventHandler<EventArgs> _canExecuteEventHandler;

        public MvxUnityEventBaseTargetBinding(TBehaviour control, string controlEvent) : base(control)
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

            _canExecuteEventHandler = OnCanExecuteChanged;
        }

        protected override void SetValueImpl(object target, object value)
        {
            _canExecuteSubscription?.Dispose();
            _canExecuteSubscription = null;
            OnSetValueImpl(value);
            RefreshEnabledState();
        }

        protected abstract void OnSetValueImpl(object value);
        protected abstract void RefreshEnabledState();

        private void OnCanExecuteChanged(object sender, EventArgs e)
        {
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
    }
}