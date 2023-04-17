using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityUIBehaviour : UIBehaviour, IDisposable
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

        ~MvxUnityUIBehaviour()
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