namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityLayerLocator
    {
        string GetDefaultSortingLayerId();
        IMvxUILayer GetLayer(string layerName);
    }
}