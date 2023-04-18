using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityLayerLocator : IMvxUnityLayerLocator
    {
        private readonly GameObject _layerRootInstance;
        private readonly IMvxUnityCameraLocator cameraLocator;

        private EventSystem _eventSystem;
        private StandaloneInputModule _standaloneInputModule;

        public MvxUnityLayerLocator(IMvxUnityCameraLocator cameraLocator, string rootInstanceName = "UIRoot")
        {
            this.cameraLocator = cameraLocator;

            _layerRootInstance = new GameObject(rootInstanceName, new []{typeof(RectTransform)});
            Object.DontDestroyOnLoad(_layerRootInstance);

            this._eventSystem = _layerRootInstance.AddComponent<EventSystem>();
            this._standaloneInputModule = _layerRootInstance.AddComponent<StandaloneInputModule>();
        }

        public void AddWindow(IMvxUnityWindow window, string cameraName, string layerName)
        {
            window.rectTransform.SetParent(this._layerRootInstance.transform);
            window.canvas.renderMode = RenderMode.ScreenSpaceCamera;
            window.canvas.worldCamera = this.cameraLocator.ResolveCamera(cameraName);
            window.canvas.sortingLayerName = layerName;
        }
    }
}