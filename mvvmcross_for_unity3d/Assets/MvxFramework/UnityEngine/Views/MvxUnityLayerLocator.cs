using System.Collections.Generic;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityLayerLocator : IMvxUnityLayerLocator
    {
        protected virtual string LayerRootName => "LayerRoot";
        protected readonly GameObject layerRootInstance;

        private readonly Dictionary<string, IMvxUILayer> _layerDict;

        public abstract string GetDefaultSortingLayerId();
        protected abstract IMvxUILayer CreateLayer(string layerName, Transform layerRoot);

        protected MvxUnityLayerLocator()
        {
            _layerDict = new Dictionary<string, IMvxUILayer>();

            layerRootInstance = new GameObject(LayerRootName);
            GameObject.DontDestroyOnLoad(layerRootInstance);
        }

        protected virtual void RegisterLayer(string layerName)
        {
            var layer = CreateLayer(layerName, layerRootInstance.transform);
            _layerDict.Add(layerName, layer);
        }

        public IMvxUILayer GetLayer(string layerName)
        {
            return _layerDict.TryGetValue(layerName, out var layer) ? layer : null;
        }
    }
}