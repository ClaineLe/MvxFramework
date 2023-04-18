using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityLayerLocator : IMvxUnityLayerLocator
    {
        protected virtual string LayerRootName => "UIRoot";
        
        protected readonly GameObject layerRootInstance;
        protected IMvxUnityCameraLocator cameraLocator;

        protected EventSystem eventSystem;
        protected StandaloneInputModule standaloneInputModule;


        public MvxUnityLayerLocator(IMvxUnityCameraLocator cameraLocator)
        {
            Debug.Log("MvxUnityLayerLocator-ctor");
            this.cameraLocator = cameraLocator;

            layerRootInstance = new GameObject(LayerRootName, new []{typeof(RectTransform)});
            GameObject.DontDestroyOnLoad(layerRootInstance);

            this.eventSystem = layerRootInstance.AddComponent<EventSystem>();
            this.standaloneInputModule = layerRootInstance.AddComponent<StandaloneInputModule>();
        }

        public void AddWindow(MvxUnityWindow window, string cameraName, string layerName)
        {
            window.rectTransform.SetParent(this.layerRootInstance.transform);
            window.canvas.renderMode = RenderMode.ScreenSpaceCamera;
            window.canvas.worldCamera = this.cameraLocator.ResolveCamera(cameraName);
            window.canvas.sortingLayerName = layerName;
        }
    }
}