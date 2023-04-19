using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Views
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup), typeof(GraphicRaycaster))]
    public abstract class MvxVisualElement : UIBehaviour, IMvxVisualElement
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;
        private GraphicRaycaster _graphicRaycaster;

        public RectTransform rectTransform
        {
            get
            {
                if (this.IsDestroyed())
                    return null;
                return _rectTransform ??= transform as RectTransform;
            }
        }

        public float Alpha
        {
            get => this.canvasGroup.alpha;
            set => this.canvasGroup.alpha = value;
        }

        public bool Visible
        {
            get => this.canvas.enabled;
            set
            {
                if (this.canvas.enabled == value)
                    return;
                this.canvas.enabled = value;
                this.OnVisibilityChanged();
            }
        }

        public bool Activated
        {
            get => !this.IsDestroyed() && this.gameObject != null && this.gameObject.activeSelf;
            protected set
            {
                if (this.IsDestroyed() || this.gameObject == null)
                    return;

                if (this.gameObject.activeSelf == value)
                    return;

                this.gameObject.SetActive(value);
            }
        }


        protected sealed override void OnEnable()
        {
            base.OnEnable();
            this.OnActivationChanged();
        }

        protected sealed override void OnDisable()
        {
            base.OnDisable();
            this.OnActivationChanged();
        }

        public bool Interactable
        {
            get => this.canvasGroup.interactable;
            set => this.canvasGroup.interactable = value;
        }

        protected virtual void OnActivationChanged()
        {
        }

        protected virtual void OnVisibilityChanged()
        {
        }

        public void SetCanvasRenderMode(RenderMode renderMode)
            => this.canvas.renderMode = renderMode;

        public void SetCanvasCamera(Camera camera)
            => this.canvas.worldCamera = camera;

        public void SetCanvasSortingLayer(string layerName)
            => this.canvas.sortingLayerName = layerName;

        public Canvas canvas
        {
            get
            {
                if (this.IsDestroyed())
                    return null;
                return _canvas ??= transform.GetComponent<Canvas>();
            }
        }

        public CanvasGroup canvasGroup
        {
            get
            {
                if (this.IsDestroyed())
                    return null;
                return _canvasGroup ??= transform.GetComponent<CanvasGroup>();
            }
        }

        public GraphicRaycaster graphicRaycaster
        {
            get
            {
                if (this.IsDestroyed())
                    return null;
                return _graphicRaycaster ??= transform.GetComponent<GraphicRaycaster>();
            }
        }


        protected override void Start()
        {
            this.ViewDidLoad();
        }

        protected virtual void ViewDidLoad()
        {
        }

        public virtual void ViewWillDisappear(bool animated)
        {
        }

        public virtual void ViewDidAppear(bool animated)
        {
        }

        public virtual void ViewWillAppear(bool animated)
        {
        }

        public virtual void ViewDidDisappear(bool animated)
        {
        }

        protected override void OnDestroy()
        {
            this.Dispose();
        }

        ~MvxVisualElement()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}