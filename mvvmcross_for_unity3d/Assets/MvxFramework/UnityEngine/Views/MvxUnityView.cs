using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityView : MvxUnityViewController, IMvxUnityView
    {
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

    public interface IMvxUnityWindow : IMvxUnityView
    {
        void AddChild(IMvxUnityView view);
    }

    public interface IMvxUnityWindow<TViewModel> : IMvxUnityWindow, IMvxUnityView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
    }
    public abstract class MvxUnityWindow : MvxUnityView, IMvxUnityWindow
    {
        public void AddChild(IMvxUnityView view)
        {
            view.rectTransform.SetParent(this.rectTransform);
            view.rectTransform.gameObject.SetActive(true);
            view.rectTransform.anchorMin = Vector2.zero;
            view.rectTransform.anchorMax = Vector2.one;
            view.rectTransform.localScale = Vector3.one;
            view.rectTransform.anchoredPosition3D = Vector3.zero;
            view.rectTransform.sizeDelta = Vector2.zero;
        }
    }


    public abstract class MvxUnityWindow<TViewModel> : MvxUnityWindow, IMvxUnityWindow<TViewModel>
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