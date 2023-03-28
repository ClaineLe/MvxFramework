using System;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Presenters.Attributes;
using MvxFramework.UnityEngine.Views;
using UnityEngine.EventSystems;

namespace MvxFramework.UnityEngine.Presenters
{
    public class MvxUnityViewPresenter : MvxAttributeViewPresenter, IMvxUnityViewPresenter
    {
        private IMvxUnityViewCreator _viewCreator;
        protected IMvxUnityViewCreator viewCreator => _viewCreator ??= Mvx.IoCProvider.Resolve<IMvxUnityViewCreator>();

        private IMvxUnityLayerLocator _layerLocator;

        protected IMvxUnityLayerLocator layerLocator =>
            _layerLocator ??= Mvx.IoCProvider.Resolve<IMvxUnityLayerLocator>();

        public override void RegisterAttributeTypes()
        {
            AttributeTypesToActionsDictionary.Register<MvxWindowPresentationAttribute>(
                async (_, attribute, request) =>
                {
                    var window = viewCreator.CreateView(request) as MvxUnityWindow;
                    return await ShowWindow(window, attribute);
                },
                async (viewModel, _) => await CloseWindow(viewModel));
        }

        public override MvxBasePresentationAttribute CreatePresentationAttribute(Type viewModelType, Type viewType)
        {
            var attribute = new MvxWindowPresentationAttribute("Normal")
            {
                ViewModelType = viewModelType,
                ViewType = viewType
            };
            return attribute;
        }

        protected virtual async Task<bool> ShowWindow(MvxUnityWindow window, MvxWindowPresentationAttribute attribute)
        {
            var layer = layerLocator.GetLayer(attribute.LayerName);
            layer.AddWindow(window);
            //window.Show();
            return true;
        }
        
        
        protected virtual async Task<bool> CloseWindow(IMvxViewModel toClose)
        {
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