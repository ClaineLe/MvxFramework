namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityLayerLocator
    {
        IMvxUILayer GetLayer(string layerName);
    }
}