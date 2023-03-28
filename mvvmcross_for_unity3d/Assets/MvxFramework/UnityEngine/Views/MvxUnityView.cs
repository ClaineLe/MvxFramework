using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Views.Base;
using UnityEngine;


namespace MvxFramework.UnityEngine.Views
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
    public abstract class MvxUnityView : MvxEventSourceUIBehaviour, IMvxUnityView
    {
        private const bool useBlocksRaycastsInsteadOfInteractable = true;
        private Canvas _canvas;

        private CanvasGroup _canvasGroup;

        protected Canvas canvas
        {
            get
            {
                if (this.IsDestroyed())
                    return null;
                return _canvas ??= GetComponent<Canvas>();
            }
        }
        
        protected CanvasGroup canvasGroup
        {
            get
            {
                if (this.IsDestroyed())
                    return null;
                return _canvasGroup ??= GetComponent<CanvasGroup>();
            }
        }

        public virtual float Alpha
        {
            get => !this.IsDestroyed() && this.gameObject != null ? this.canvasGroup.alpha : 0f;
            set { if (!this.IsDestroyed() && this.gameObject != null) this.canvasGroup.alpha = value; }
        }

        public virtual bool Interactable
        {
            get
            {
                if (this.IsDestroyed() || this.gameObject == null)
                    return false;

                if (useBlocksRaycastsInsteadOfInteractable)
                    return this.canvasGroup.blocksRaycasts;
                return this.canvasGroup.interactable;
            }
            set
            {
                if (this.IsDestroyed() || this.gameObject == null)
                    return;

                if (useBlocksRaycastsInsteadOfInteractable)
                    this.canvasGroup.blocksRaycasts = value;
                else
                    this.canvasGroup.interactable = value;
            }
        }
        
        public virtual bool Visibility
        {
            get { return !this.IsDestroyed() && this.gameObject != null ? this.gameObject.activeSelf : false; }
            set
            {
                if (this.IsDestroyed() || this.gameObject == null)
                    return;

                if (this.gameObject.activeSelf == value)
                    return;

                this.gameObject.SetActive(value);
            }
        }

        public object DataContext
        {
            get => BindingContext.DataContext;
            set => BindingContext.DataContext = value;
        }

        public IMvxViewModel ViewModel
        {
            get => DataContext as IMvxViewModel;
            set => DataContext = value;
        }

        public IMvxBindingContext BindingContext { get; set; }


        void IMvxUnityView.ViewLoaded()
        {
            this.OnViewCreate(); //MvxUIBehaviourExtensions.OnViewCreate加载ViewModel
            ViewModel.ViewCreated();
            this.OnViewLoaded();
        }

        protected abstract void OnViewLoaded();


        public MvxViewModelRequest Request { get; set; }
    }

    public abstract class MvxUnityView<TViewModel> : MvxUnityView, IMvxUnityView<TViewModel>
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