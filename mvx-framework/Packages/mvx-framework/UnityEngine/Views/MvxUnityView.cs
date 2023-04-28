using System.Threading.Tasks;
using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityView : MvxUnityViewController, IMvxUnityView
    {
        protected virtual string ActivateAnimationName => "Activate";
        protected virtual string PassivateAnimationName => "Passivate";
        protected virtual string DismissAnimationName => PassivateAnimationName; //"Dismiss";

        public virtual async Task<bool> Activate(bool animated)
        {
            if (Activated == false)
                Activated = true;

            if (Visible == false)
                Visible = true;

            //Debug.Log("Activate - animated:" + animated + ", canPlay:" + CanPlayAnimation());
            this.ViewWillAppear(animated);
            if (animated && CanPlayAnimation())
                await PlayAnimation(ActivateAnimationName);
            this.ViewDidAppear(animated);
            return true;
        }

        public virtual async Task<bool> Passivate(bool animated)
        {
            //Debug.Log("Passivate - animated:" + animated + ", canPlay:" + CanPlayAnimation());
            this.ViewWillDisappear(animated);
            if (animated && CanPlayAnimation())
                await PlayAnimation(PassivateAnimationName);
            this.ViewDidDisappear(animated);
            return true;
        }

        public virtual async Task<bool> Dismiss(bool animated)
        {
            //Debug.Log("Dismiss - animated:" + animated + ", canPlay:" + CanPlayAnimation());
            Activated = true;
            this.ViewWillDisappear(animated);
            if (animated && CanPlayAnimation())
                await PlayAnimation(DismissAnimationName);
            this.ViewDidDisappear(animated);
            GameObject.Destroy(gameObject);
            return true;
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