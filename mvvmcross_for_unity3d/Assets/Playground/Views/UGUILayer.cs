using MvxFramework.UnityEngine.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Playground.Views
{
    [RequireComponent(typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster))]
    public class MvxUnityLayer : UIBehaviour, IMvxUILayer
    {
        protected Canvas canvas;
        protected CanvasScaler canvasScaler;
        protected GraphicRaycaster graphicRaycaster;

        public static MvxUnityLayer Create(string layerName, int sortingLayerId, IMvxUnityCameraLocator cameraLocator, Transform layerRoot)
        {
            var layerInstance = new GameObject(layerName);
            layerInstance.transform.SetParent(layerRoot);
            var layer = layerInstance.AddComponent<MvxUnityLayer>();
            layer.canvas = layerInstance.GetComponent<Canvas>();
            layer.canvasScaler = layerInstance.GetComponent<CanvasScaler>();
            layer.graphicRaycaster = layerInstance.GetComponent<GraphicRaycaster>();

            layer.canvas.sortingLayerID = sortingLayerId;
            layer.canvas.worldCamera = cameraLocator.UI2DCamera;
            layer.canvas.renderMode = RenderMode.ScreenSpaceCamera;
            return layer;
        }

        public void AddWindow(MvxUnityView view)
        {
            var rectTransform = view.transform as RectTransform;
            rectTransform.SetParent(this.transform);
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.localScale = Vector3.one;
            rectTransform.anchoredPosition3D = Vector3.zero;
            rectTransform.sizeDelta = Vector2.zero;
        }
    }
}