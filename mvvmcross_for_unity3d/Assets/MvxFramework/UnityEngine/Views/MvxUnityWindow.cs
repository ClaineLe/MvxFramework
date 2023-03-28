using System;
using Microsoft.Extensions.Logging;
using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityWindow : MvxUnityWindowView, IMvxUnityWindow
    {
        
        private bool activated = false;
        private EventHandler activatedChanged;

        public bool Activated
        {
            get => this.activated;
            protected set
            {
                if (this.activated == value)
                    return;

                this.activated = value;
                this.OnActivatedChanged();
                this.RaiseActivatedChanged();
            }
        }
        
        protected virtual void OnActivatedChanged()
        {
            this.Interactable = this.Activated;
        }
        
        protected void RaiseActivatedChanged()
        {
            try
            {
                this.activatedChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                log.LogWarning("{0}", e);
            }
        }
    }

    public abstract class MvxUnityWindow<TViewModel> : MvxUnityWindow, IMvxUnityWindow<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        public MvxFluentBindingDescriptionSet<IMvxUnityView<TViewModel>, TViewModel> CreateBindingSet()
        {
            return this.CreateBindingSet<IMvxUnityView<TViewModel>, TViewModel>();
        }

        public new TViewModel ViewModel
        {
            get => base.ViewModel as TViewModel;
            set => base.ViewModel = value;
        }
    }


}