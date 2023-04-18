using System.Threading.Tasks;
using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityView : MvxUnityViewController, IMvxUnityView
    {
        public virtual async Task<bool> Activate(bool animated)
        {
            Debug.Log("Activate");
            if (Activated == false)
                Activated = true;
            
            if (Visible == false)
                Visible = true;

            return true;
        }

        public virtual async Task<bool> Passivate(bool animated)
        {
            return true;
        }

        public virtual async Task<bool> Dismiss(bool animated)
        {
            Activated = true;
            return true;
        }

        protected sealed override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.OnViewLoaded();
        }

        public sealed override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            this.OnViewWillDisappear();
        }

        public sealed override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            this.OnViewDidAppear();
        }

        public sealed override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.OnViewWillAppear();
        }

        public sealed override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            this.OnViewDidDisappear();
        }

        protected sealed override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.OnDispose();
        }

        protected abstract void OnViewLoaded();

        protected virtual void OnViewWillDisappear()
        {
        }

        protected virtual void OnViewDidAppear()
        {
        }

        protected virtual void OnViewWillAppear()
        {
        }

        protected virtual void OnViewDidDisappear()
        {
        }

        protected virtual void OnDispose()
        {
        }
    }

    public abstract class MvxUnityView<TViewModel> : MvxUnityView, IMvxUnityView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get => base.ViewModel as TViewModel;
            set => base.ViewModel = value;
        }

        public MvxFluentBindingDescriptionSet<IMvxUnityView<TViewModel>, TViewModel> CreateBindingSet()
        {
            return this.CreateBindingSet<IMvxUnityView<TViewModel>, TViewModel>();
        }
    }
}