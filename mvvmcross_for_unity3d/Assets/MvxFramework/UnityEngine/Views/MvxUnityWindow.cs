using System.Threading.Tasks;
using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityWindow : MvxUnityWindowView, IMvxUnityWindow
    {
        public string SerialKey { get; protected set; }
        public new IMvxUILayer ParentUI => layer;

        protected IMvxUILayer layer;
        public void SetLayer(IMvxUILayer layer)
        {
            this.layer = layer;
        }

        public virtual async Task Activate(bool animated = true)
        {
            this.Activated = true;
        }

        public virtual async Task Passivate(bool animated = true)
        {
            this.Activated = false;
        }

        public virtual async Task Show(bool animated = true)
        {
            this.Visibility = true;
            await this.Activate(animated);
        }

        public virtual async Task Hide(bool animated = true)
        {
            await this.Passivate(animated);
            this.Visibility = false;
        }

        public void Dismiss(bool animated = true)
        {
            if (!this.IsDestroyed() && this.gameObject != null)
                GameObject.Destroy(this.gameObject);
        }

        protected override void OnActivatedChanged()
        {
            base.OnActivatedChanged();
            if (canvas.overrideSorting == false)
            {
                canvas.overrideSorting = true;
                canvas.sortingLayerID = this.layer.sortingLayerID;
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