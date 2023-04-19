using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Logging;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Presenters.Attributes;
using MvxFramework.UnityEngine.Views;
using UnityEngine;

namespace MvxFramework.UnityEngine.Presenters
{
    public class MvxUnityViewPresenter : MvxAttributeViewPresenter, IMvxUnityViewPresenter
    {
        private IMvxUnityViewCreator _viewCreator;

        private IMvxUnityLayerLocator _layerLocator;
        //private IMvxUnityWindow currentWindow;

        protected IMvxUnityViewCreator viewCreator => _viewCreator ??= Mvx.IoCProvider.Resolve<IMvxUnityViewCreator>();

        protected IMvxUnityLayerLocator layerLocator =>
            _layerLocator ??= Mvx.IoCProvider.Resolve<IMvxUnityLayerLocator>();

        protected MvxLinkedStack<IMvxUnityWindow> LinkedStack = new();

        public override void RegisterAttributeTypes()
        {
            AttributeTypesToActionsDictionary.Register<MvxContentPresentationAttribute>(
                (_, attribute, request) =>
                {
                    var visualElement = viewCreator.CreateView(request);
                    return ShowContent(visualElement, attribute);
                },
                (viewModel, _) => CloseContent(viewModel));

            AttributeTypesToActionsDictionary.Register<MvxWindowPresentationAttribute>(
                (_, attribute, request) =>
                {
                    var visualElement = viewCreator.CreateView(request);
                    return ShowWindow(visualElement, attribute);
                },
                (viewModel, _) => CloseWindow(viewModel));
        }

        public override MvxBasePresentationAttribute CreatePresentationAttribute(Type viewModelType, Type viewType)
        {
            if (viewType.IsSubclassOf(typeof(MvxUnityWindow)))
            {
                MvxLogHost.Default?.LogInformation(
                    $"PresentationAttribute not found for {viewType.Name}. Assuming window presentation");
                return new MvxWindowPresentationAttribute(MvxUIDefine.CAM.twoD, MvxUIDefine.LAYER.normal)
                {
                    ViewModelType = viewModelType,
                    ViewType = viewType
                };
            }

            MvxLogHost.Default?.LogInformation(
                $"PresentationAttribute not found for {viewType.Name}. Assuming content presentation");
            return new MvxContentPresentationAttribute { ViewType = viewType, ViewModelType = viewModelType };
        }


        protected virtual Task<bool> ShowWindow(IMvxVisualElement visualElement,
            MvxWindowPresentationAttribute attribute)
        {
            Debug.Log("ShowWindow");
            if (visualElement is not IMvxUnityWindow window)
                return Task.FromResult(false);

            LinkedStack.Push(window);
            layerLocator.AddWindow(window, attribute.CameraName, attribute.LayerName);
            return window.Activate(true);
        }

        protected virtual Task<bool> CloseWindow(IMvxViewModel windowModel)
        {
            var topWindow = LinkedStack.Peek();
            if (topWindow == null)
            {
                Debug.LogError($"没有找到TopWindow");
                return Task.FromResult(false);
            }

            return topWindow.Dismiss(true);
        }

        protected virtual Task<bool> ShowContent(IMvxVisualElement visualElement,
            MvxContentPresentationAttribute attribute)
        {
            if (visualElement is not IMvxUnityView view)
                return Task.FromResult(false);

            var window = LinkedStack.Peek();
            window.AddChild(view);
            return view.Activate(true);
        }

        protected virtual Task<bool> CloseContent(IMvxViewModel viewModel)
        {
            var topWindow = LinkedStack.Peek();
            if (topWindow == null)
            {
                Debug.LogError($"没有找到TopWindow");
                return Task.FromResult(false);
            }

            var viewList = topWindow.LinkedStack.FindAll(a => a.ViewModel == viewModel);
            if (viewList.Count != 1)
            {
                Debug.LogError($"找寻窗口出错：windowList.Count = {viewList.Count}");
                return Task.FromResult(false);
            }

            var view = viewList[0];
            topWindow.RemoveChild(view);
            return view.Dismiss(true);
        }
    }
}