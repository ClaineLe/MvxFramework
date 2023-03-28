namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityLayerLocator : IMvxUnityLayerLocator
    {
        public abstract IMvxUILayer GetLayer(string layerName);
    }
}