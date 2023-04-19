namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityLayerLocator
    {
        void AddWindow(IMvxUnityWindow window, string cameraName, string layerName);
    }
}