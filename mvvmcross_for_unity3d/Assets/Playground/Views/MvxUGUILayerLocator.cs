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


        public MvxUGUILayerLocator(IMvxUnityCameraLocator cameraLocator)
        {
            this.cameraLocator = cameraLocator;
            this.eventSystem = layerRootInstance.AddComponent<EventSystem>();
            this.standaloneInputModule = layerRootInstance.AddComponent<StandaloneInputModule>();
            
            RegisterLayer( LAYER.normal);
            RegisterLayer(LAYER.plot);
            RegisterLayer(LAYER.guide);
            RegisterLayer(LAYER.top);
            RegisterLayer(LAYER.loading);
            RegisterLayer(LAYER.system);
        }

        public override string GetDefaultSortingLayerId() => LAYER.normal;

        protected override IMvxUILayer CreateLayer(string layerName, Transform layerRoot)
            => MvxUnityLayer.Create(layerName, this.cameraLocator, layerRoot);
    }
}