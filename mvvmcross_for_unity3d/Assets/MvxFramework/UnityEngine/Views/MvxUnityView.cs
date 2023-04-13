using MvvmCross.Binding.BindingContext;
using MvvmCross.Logging;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Views.Base;
using UnityEngine;
using UnityEngine.UI;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace MvxFramework.UnityEngine.Views
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup), typeof(GraphicRaycaster))]
    public abstract class MvxUnityView : MvxEventSourceUIBehaviour, IMvxUnityView
    {
        protected ILogger log => MvxLogHost.GetLog(this.GetType().Name);
        private Canvas _canvas;

        private CanvasGroup _canvasGroup;

        private GraphicRaycaster _graphicRaycaster;
        private bool _activated = false;
        public int SortingOrder
        {
            get => canvas.sortingOrder;
            set => canvas.sortingOrder = value;
        }

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

        private GraphicRaycaster graphicRaycaster
        {
            get
            {
                if (this.IsDestroyed())
                    return null;
                return _graphicRaycaster ??= GetComponent<GraphicRaycaster>();
            }
        }

        public virtual float Alpha
        {
            get => !this.IsDestroyed() && this.gameObject != null ? this.canvasGroup.alpha : 0f;
            set
            {
                if (!this.IsDestroyed() && this.gameObject != null) this.canvasGroup.alpha = value;
            }
        }

        public virtual bool Interactable
        {
            get
            {
                if (this.IsDestroyed() || this.gameObject == null)
                    return false;

                return graphicRaycaster.enabled;
            }
            set
            {
                if (this.IsDestroyed() || this.gameObject == null)
                    return;
                graphicRaycaster.enabled = value;
            }
        }

        public virtual bool Visibility
        {
            get => !this.IsDestroyed() && this.gameObject != null && this.gameObject.activeSelf;
            set
            {
                if (this.IsDestroyed() || this.gameObject == null)
                    return;

                if (this.gameObject.activeSelf == value)
                    return;

                this.gameObject.SetActive(value);
            }
        }

        public bool Activated
        {
            get => this._activated;
            protected set
            {
                if (this._activated == value)
                    return;

                this._activated = value;
                this.OnActivatedChanged();
            }
        }
        
        protected virtual void OnActivatedChanged()
        {
            this.Interactable = this.Activated;
        }
        
        public IMvxAnimation EnterAnimation { get; set; }
        public IMvxAnimation ExitAnimation { get; set; }

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
            this.Visibility = false;
            this.Interactable = this.Activated;
            this.OnViewCreate(); //MvxUIBehaviourExtensions.OnViewCreate加载ViewModel
            ViewModel.ViewCreated();
            this.OnViewLoaded();
        }

        protected abstract void OnViewLoaded();

        public MvxViewModelRequest Request { get; set; }
        public IMvxUIUnit ParentUI { get; }
        
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