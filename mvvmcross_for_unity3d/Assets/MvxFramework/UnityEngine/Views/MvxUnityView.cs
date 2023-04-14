using System.Collections.Generic;
using MvvmCross.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityView<TViewModel> : MvxUnityViewController<TViewModel>
        where TViewModel : class, IMvxViewModel
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

    
    
    
    
    
    
    
    
    public abstract class MvxListView<TViewModel> : MvxUnityViewController<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        public ScrollRect scrollRect; // 滚动区域
        public VerticalLayoutGroup layoutGroup; // 垂直布局组
        public GameObject itemPrefab; // 列表项预制件

        private List<GameObject> itemList = new List<GameObject>(); // 列表项列表

        // 添加新的列表项
        public void AddItem(string label)
        {
            // 实例化新的列表项并设置父级和文本
            GameObject newItem = Instantiate(itemPrefab);
            newItem.transform.SetParent(layoutGroup.transform, false);
            newItem.GetComponentInChildren<Text>().text = label;

            // 将列表项添加到列表项列表中
            itemList.Add(newItem);

            // 重新计算滚动视图的大小以容纳全部内容
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)scrollRect.content.transform);

            // 将滚动视图定位在底部以显示最新的内容
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }
    
    
}