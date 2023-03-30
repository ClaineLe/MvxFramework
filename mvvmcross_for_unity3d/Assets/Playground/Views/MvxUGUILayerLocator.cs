using MvxFramework.UnityEngine.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Views
{
    public class MvxUGUILayerLocator : MvxUnityLayerLocator
    {
        protected EventSystem eventSystem;
        protected StandaloneInputModule standaloneInputModule;
        protected IMvxUnityCameraLocator cameraLocator;

        private const int DefaultSortingLayerId = (int)LAYER.normal;

        public MvxUGUILayerLocator(IMvxUnityCameraLocator cameraLocator)
        {
            this.cameraLocator = cameraLocator;
            this.eventSystem = layerRootInstance.AddComponent<EventSystem>();
            this.standaloneInputModule = layerRootInstance.AddComponent<StandaloneInputModule>();
            
            RegisterLayer("Normal", LAYER.normal);
            RegisterLayer("Plot",LAYER.plot);
            RegisterLayer("Guide",LAYER.guide);
            RegisterLayer("Top",LAYER.top);
            RegisterLayer("Loading",LAYER.loading);
            RegisterLayer("System",LAYER.system);
        }

        private void RegisterLayer(string layerName, int sortingLayerId)
            => base.RegisterLayer(layerName, sortingLayerId);

        public override int GetDefaultSortingLayerId()
            => DefaultSortingLayerId;

        protected override IMvxUILayer CreateLayer(string layerName, int sortingLayerId, Transform layerRoot)
            => MvxUnityLayer.Create(layerName, sortingLayerId, this.cameraLocator, layerRoot);
    }
}