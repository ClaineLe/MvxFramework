using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
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
            this.OnAddChild(view);
        }

        protected virtual void OnAddChild(IMvxUnityView view)
        {
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