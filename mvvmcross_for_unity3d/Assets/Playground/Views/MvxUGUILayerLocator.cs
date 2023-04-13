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
            RegisterLayer<MvxUnityLayer>(UILayer.BackGround);
            RegisterLayer<MvxUnityLayer>(UILayer.ThreeD);
            RegisterLayer<MvxUnityTwoDLayer>(UILayer.TwoD);
            RegisterLayer<MvxUnityLayer>(UILayer.Top);
        }

        public override string GetDefaultSortingLayerName() => UILayer.TwoD;
        protected override IMvxUILayer CreateLayer<TLayer>(string layerName, Transform layerRoot)
        {
            var layerInstance = new GameObject(layerName);
            layerInstance.transform.SetParent(layerRoot);
            var layer = layerInstance.AddComponent<TLayer>() as MvxUnityLayer;
            layer.Initialize(this.cameraLocator);
            return layer;
        }
    }
}