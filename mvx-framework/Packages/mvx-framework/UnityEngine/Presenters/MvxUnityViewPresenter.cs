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
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace MvxFramework.UnityEngine.Presenters
{
    public class MvxUnityViewPresenter : MvxAttributeViewPresenter, IMvxUnityViewPresenter
    {
        private bool ResourceMode { get; }
        private string DefAssetPath { get; }

        private readonly ILogger? _log = MvxLogHost.GetLog<MvxUnityViewPresenter>();

        private IMvxUnityViewCreator _viewCreator;

        private IMvxUnityLayerLocator _layerLocator;

        protected IMvxUnityViewCreator viewCreator => _viewCreator ??= Mvx.IoCProvider.Resolve<IMvxUnityViewCreator>();

        protected IMvxUnityLayerLocator layerLocator =>
            _layerLocator ??= Mvx.IoCProvider.Resolve<IMvxUnityLayerLocator>();

        private readonly MvxLinkedStack<IMvxUnityWindow> _linkedStack = new();

        public MvxUnityViewPresenter(bool resourceMode = true, string defAssetPath = "")
        {
            this.ResourceMode = resourceMode;
            this.DefAssetPath = defAssetPath;
        }

        public override void RegisterAttributeTypes()
        {
            AttributeTypesToActionsDictionary.Register<MvxContentPresentationAttribute>(
                async (_, attribute, request) =>
                {
                    var visualElement = await viewCreator.CreateViewAsync(request, attribute);
                    return await ShowContent(visualElement, attribute);
                },
                (viewModel, _) => CloseContent(viewModel));

            AttributeTypesToActionsDictionary.Register<MvxWindowPresentationAttribute>(
                async (_, attribute, request) =>
                {
                    var visualElement = await viewCreator.CreateViewAsync(request, attribute);
                    return await ShowWindow(visualElement, attribute);
                },
                (viewModel, _) => CloseWindow(viewModel));
        }

        public override MvxBasePresentationAttribute CreatePresentationAttribute(Type viewModelType, Type viewType)
        {
            if (viewType.IsSubclassOf(typeof(MvxUnityWindow)))
            {
                //_log?.LogInformation($"PresentationAttribute not found for {viewType.Name}. Assuming window presentation");
                return new MvxWindowPresentationAttribute(DefAssetPath, resourceModel: true)
                {
                    ViewModelType = viewModelType,
                    ViewType = viewType
                };
            }

            //_log?.LogInformation($"PresentationAttribute not found for {viewType.Name}. Assuming content presentation");
            return new MvxContentPresentationAttribute(DefAssetPath, true)
            {
                ViewType = viewType,
                ViewModelType = viewModelType
            };
        }


        protected virtual Task<bool> ShowWindow(IMvxVisualElement visualElement,
            MvxWindowPresentationAttribute attribute)
        {
            if (visualElement is not IMvxUnityWindow window)
                return Task.FromResult(false);

            _linkedStack.Push(window);
            layerLocator.AddWindow(window, attribute.CameraName, attribute.LayerName);
            return window.Activate(true);
        }

        protected virtual Task<bool> CloseWindow(IMvxViewModel windowModel)
        {
            var topWindow = _linkedStack.Peek();
            if (topWindow == null)
            {
                _log?.LogError($"没有找到TopWindow");
                return Task.FromResult(false);
            }

            if (topWindow.ViewModel != windowModel)
            {
                _log?.LogWarning($"Could not close ViewModel type {windowModel.GetType().Name}");
                return Task.FromResult(false);
            }

            return topWindow.Dismiss(true);
        }

        protected virtual Task<bool> ShowContent(IMvxVisualElement visualElement,
            MvxContentPresentationAttribute attribute)
        {
            if (visualElement is not IMvxUnityView view)
                return Task.FromResult(false);

            var window = _linkedStack.Peek();
            window.AddChild(view);
            return view.Activate(true);
        }

        protected virtual Task<bool> CloseContent(IMvxViewModel viewModel)
        {
            var topWindow = _linkedStack.Peek();
            if (topWindow == null)
            {
                _log?.LogError($"没有找到TopWindow");
                return Task.FromResult(false);
            }

            var viewList = topWindow.LinkedStack.FindAll(a => a.ViewModel == viewModel);
            if (viewList.Count != 1)
            {
                _log?.LogError($"找寻窗口出错：windowList.Count = {viewList.Count}");
                return Task.FromResult(false);
            }

            var view = viewList[0];
            topWindow.RemoveChild(view);
            return view.Dismiss(true);
        }
    }
}