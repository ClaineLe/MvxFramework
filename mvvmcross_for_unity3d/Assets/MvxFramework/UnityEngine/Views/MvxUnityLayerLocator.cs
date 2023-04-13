using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityLayerLocator : IMvxUnityLayerLocator
    {
        protected virtual string LayerRootName => "LayerRoot";
        protected readonly GameObject layerRootInstance;

        private readonly Dictionary<string, IMvxUILayer> _layerDict;

        public abstract string GetDefaultSortingLayerName();

        protected abstract IMvxUILayer CreateLayer<TLayer>(string layerName, Transform layerRoot)
            where TLayer : UIBehaviour, IMvxUILayer;

        protected MvxUnityLayerLocator()
        {
            _layerDict = new Dictionary<string, IMvxUILayer>();

            layerRootInstance = new GameObject(LayerRootName);
            GameObject.DontDestroyOnLoad(layerRootInstance);
        }

        protected virtual void RegisterLayer<TLayer>(string layerName)where TLayer : UIBehaviour, IMvxUILayer
        {
            var layer = CreateLayer<TLayer>(layerName, layerRootInstance.transform);
            _layerDict.Add(layerName, layer);
        }

        public IMvxUILayer GetLayer(string layerName)
        {
            return _layerDict.TryGetValue(layerName, out var layer) ? layer : null;
        }
    }
}