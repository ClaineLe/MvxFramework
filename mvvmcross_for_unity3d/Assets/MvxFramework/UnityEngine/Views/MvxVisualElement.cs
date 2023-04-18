using System;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxVisualElement : UIBehaviour, IMvxVisualElement
    {
        private RectTransform _rectTransform;

        public RectTransform rectTransform
        {
            get
            {
                if (this.IsDestroyed())
                    return null;
                return _rectTransform ??= transform as RectTransform;
            }
        }

        private Canvas _canvas;

        public Canvas canvas
        {
            get
            {
                if (this.IsDestroyed())
                    return null;
                return _canvas ??= transform.GetComponent<Canvas>();
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