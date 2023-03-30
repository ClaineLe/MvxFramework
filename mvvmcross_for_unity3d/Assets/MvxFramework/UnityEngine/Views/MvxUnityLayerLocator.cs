using System.Collections.Generic;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityLayerLocator : IMvxUnityLayerLocator
    {
        protected virtual string LayerRootName => "LayerRoot";
        protected readonly GameObject layerRootInstance;

        private readonly Dictionary<int, IMvxUILayer> _layerDict;

        public abstract int GetDefaultSortingLayerId();
        protected abstract IMvxUILayer CreateLayer(string layerName, int sortingLayerId, Transform layerRoot);

        protected MvxUnityLayerLocator()
        {
            _layerDict = new Dictionary<int, IMvxUILayer>();

            layerRootInstance = new GameObject(LayerRootName);
            GameObject.DontDestroyOnLoad(layerRootInstance);
        }

        protected virtual void RegisterLayer(string layerName, int sortingLayerId)
        {
            var layer = CreateLayer(layerName, sortingLayerId, layerRootInstance.transform);
            _layerDict.Add(sortingLayerId, layer);
        }

        public IMvxUILayer GetLayer(int sortingLayerId)
        {
            return _layerDict.TryGetValue(sortingLayerId, out var layer) ? layer : null;
        }
    }
}