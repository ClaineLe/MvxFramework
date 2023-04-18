using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Views
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup), typeof(GraphicRaycaster))]
    public class MvxVisualElement : UIBehaviour, IMvxVisualElement
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


        protected virtual void Start()
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

        protected virtual void OnDestroy()
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