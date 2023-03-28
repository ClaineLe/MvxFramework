using System.Collections.Generic;
using MvxFramework.UnityEngine.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Playground.Views
{
    [RequireComponent(typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster))]
    public class UGUILayer : UIBehaviour, IMvxUILayer
    {
        protected Canvas canvas;
        protected CanvasScaler canvasScaler;
        protected GraphicRaycaster graphicRaycaster;
        public static UGUILayer Create(string layerName, IMvxUnityCameraLocator cameraLocator, Transform layerRoot)
        {
            var layerInstance = new GameObject(layerName);
            layerInstance.transform.SetParent(layerRoot);
            var layer = layerInstance.AddComponent<UGUILayer>();
            layer.canvas = layerInstance.GetComponent<Canvas>();
            layer.canvasScaler = layerInstance.GetComponent<CanvasScaler>();
            layer.graphicRaycaster = layerInstance.GetComponent<GraphicRaycaster>();
            
            layer.canvas.sortingLayerName = layerName;
            layer.canvas.worldCamera = cameraLocator.UI2DCamera;
            layer.canvas.renderMode = RenderMode.ScreenSpaceCamera;
            return layer;
        }

        public void AddWindow(MvxUnityView view)
        {
            var rectTransform =view.transform as RectTransform;
            rectTransform.SetParent(this.transform);
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.localScale = Vector3.one;
            rectTransform.anchoredPosition3D = Vector3.zero;
            rectTransform.sizeDelta = Vector2.zero;
        }
    }

    public class MvxUGUILayerLocator : MvxUnityLayerLocator
    {
        protected GameObject layerRootInstance;
        protected IMvxUnityCameraLocator cameraLocator;

        private Dictionary<string, IMvxUILayer> _layerDict;
        public MvxUGUILayerLocator(IMvxUnityCameraLocator cameraLocator)
        {
            _layerDict = new Dictionary<string, IMvxUILayer>();
            
            this.cameraLocator = cameraLocator;
            const string ASSET_NAME = "LayerRoot"; 
            layerRootInstance = new GameObject(ASSET_NAME);
            GameObject.DontDestroyOnLoad(layerRootInstance);
            registerLayer("Normal");
            registerLayer("Plot");
            registerLayer("Guide");
            registerLayer("Top");
            registerLayer("Loading");
            registerLayer("System");
        }

        protected void registerLayer(string layerName)
        {
            var layer = UGUILayer.Create(layerName, cameraLocator, layerRootInstance.transform);
            _layerDict.Add(layerName, layer);
        }

        public override IMvxUILayer GetLayer(string layerName)
        {
            return _layerDict.TryGetValue(layerName, out var layer) ? layer : null;
        }
    }
}