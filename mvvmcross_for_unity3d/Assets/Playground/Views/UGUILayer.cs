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

        public void Initialize(IMvxUnityCameraLocator cameraLocator)
        {
            this.canvas = transform.GetComponent<Canvas>();
            this.canvasScaler = transform.GetComponent<CanvasScaler>();
            this.graphicRaycaster = transform.GetComponent<GraphicRaycaster>();

            this.canvas.renderMode = RenderMode.ScreenSpaceCamera;
            this.canvas.worldCamera = cameraLocator.UI2DCamera;
            this.canvas.sortingLayerName = name;
        }

        public int sortingLayerID => canvas.sortingLayerID;

        public void AddView(IMvxUnityView unityView)
        {
            if (unityView is not MvxUnityViewController viewController) 
                return;
            
            var rectTransform = viewController.transform as RectTransform;
            if (rectTransform == null)
                return;
            
            rectTransform.SetParent(this.transform);
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.localScale = Vector3.one;
            rectTransform.anchoredPosition3D = Vector3.zero;
            rectTransform.sizeDelta = Vector2.zero;
            //window.SetLayer(this);

        }
    }
}