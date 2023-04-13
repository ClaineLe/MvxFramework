namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityLayerLocator
    {
        string GetDefaultSortingLayerName();
        IMvxUILayer GetLayer(string layerName);
    }
}