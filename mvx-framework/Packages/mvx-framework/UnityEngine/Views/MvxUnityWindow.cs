using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityWindow : MvxUnityView, IMvxUnityWindow
    {
        private MvxLinkedStack<IMvxUnityView> _linkedStack = new();

        public MvxLinkedStack<IMvxUnityView> LinkedStack => _linkedStack;

        public void AddChild(IMvxUnityView view, bool enterStack = true)
        {
            var childRectTransform = view.rectTransform;
            childRectTransform.SetParent(this.rectTransform);
            childRectTransform.gameObject.SetActive(true);
            childRectTransform.anchorMin = Vector2.zero;
            childRectTransform.anchorMax = Vector2.one;
            childRectTransform.localScale = Vector3.one;
            childRectTransform.anchoredPosition3D = Vector3.zero;
            childRectTransform.sizeDelta = Vector2.zero;
            this.OnAddChild(view);
            if(enterStack)
                this.LinkedStack.Push(view);
        }

        public void RemoveChild(IMvxUnityView view)
        {
            this.LinkedStack.RemoveAll(v => v == view);
            this.OnRemoveChild(view);
        }

        protected virtual void OnAddChild(IMvxUnityView view)
        {
        }

        protected virtual void OnRemoveChild(IMvxUnityView view)
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