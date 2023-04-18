using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Presenters.Attributes;
using MvxFramework.UnityEngine.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MvxFramework.UnityEngine.Presenters
{
    public class MvxUnityViewPresenter : MvxAttributeViewPresenter, IMvxUnityViewPresenter
    {
        private IMvxUnityViewCreator _viewCreator;

        private IMvxUnityLayerLocator _layerLocator;
        //private readonly Dictionary<IMvxViewModel, IMvxUnityWindow> _windowDict = new ();

        protected IMvxUnityViewCreator viewCreator => _viewCreator ??= Mvx.IoCProvider.Resolve<IMvxUnityViewCreator>();

        protected IMvxUnityLayerLocator layerLocator =>
            _layerLocator ??= Mvx.IoCProvider.Resolve<IMvxUnityLayerLocator>();


        public override void RegisterAttributeTypes()
        {
            AttributeTypesToActionsDictionary.Register<MvxWindowPresentationAttribute>(
                async (_, attribute, request) => await ShowWindow(request, attribute),
                async (viewModel, _) => await CloseWindow(viewModel));
        }

        public override MvxBasePresentationAttribute CreatePresentationAttribute(Type viewModelType, Type viewType)
        {
            var attribute = new MvxWindowPresentationAttribute(MvxUIDefine.CAM.twoD, MvxUIDefine.LAYER.normal)
            {
                ViewModelType = viewModelType,
                ViewType = viewType
            };
            return attribute;
        }

        private IMvxUnityWindow currentWindow;

        protected virtual async Task<bool> ShowWindow(MvxViewModelRequest request,
            MvxWindowPresentationAttribute attribute)
        {
            var view = viewCreator.CreateView(request);
            if (view is IMvxUnityWindow window)
            {
                currentWindow = window;
                layerLocator.AddWindow(window, attribute.CameraName, attribute.LayerName);
                //window.rectTransform.gameObject.SetActive(true);
                return true;
            }

            if (currentWindow == null)
                throw new ArgumentNullException(nameof(currentWindow));

            currentWindow.AddChild(view);

            //var view = viewCreator.CreateView(request) as MvxUnityWindow;
            //_windowDict.Add(view.ViewModel, view);
            //var layer = layerLocator.GetLayer(attribute.layerName);
            //layer.AddView(view);
            //layer.AddWindow(view);
            //await view.Show();
            return true;
        }


        protected virtual async Task<bool> CloseWindow(IMvxViewModel toClose)
        {
            /*
            if(_windowDict.TryGetValue(toClose, out var window) == false)
            {
                Debug.LogError($"无法关闭当前窗口.destVM:{toClose}");
                return false;
            }
            window.Dismiss(true);
            */
            return true;
        }

        private static void ValidateArguments(Type viewModelType, Type viewType)
        {
            if (viewModelType == null)
                throw new ArgumentNullException(nameof(viewModelType));

            if (viewType == null)
                throw new ArgumentNullException(nameof(viewType));
        }

        private static void ValidateArguments(UIBehaviour viewController, MvxBasePresentationAttribute attribute)
        {
            if (viewController == null)
                throw new ArgumentNullException(nameof(viewController));

            if (attribute == null)
                throw new ArgumentNullException(nameof(attribute));
        }

        private static void ValidateArguments(IMvxViewModel viewModel, MvxBasePresentationAttribute attribute)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            if (attribute == null)
                throw new ArgumentNullException(nameof(attribute));
        }
    }
}