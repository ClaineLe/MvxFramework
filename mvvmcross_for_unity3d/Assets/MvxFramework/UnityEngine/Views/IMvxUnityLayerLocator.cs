namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityLayerLocator
    {
        //string GetDefaultSortingLayerName();
        //IMvxUILayer GetLayer(string layerName);

        void AddWindow(MvxUnityWindow window, string cameraName, string layerName);
    }
}