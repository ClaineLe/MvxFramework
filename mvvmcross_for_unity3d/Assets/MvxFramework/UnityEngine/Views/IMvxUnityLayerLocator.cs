namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityLayerLocator
    {
        int GetDefaultSortingLayerId();
        IMvxUILayer GetLayer(int sortingLayerId);
    }
}