using MvxFramework.UnityEngine.Views;

namespace MvxFramework.UnityEngine.Presenters.Attributes
{
    public class MvxWindowPresentationAttribute : MvxUnityBasePresentationAttribute
    {
        public string CameraName { get; }

        public string LayerName { get; }

        public MvxWindowPresentationAttribute(string assetPath, string cameraName = MvxUIDefine.CAM.twoD, string layerName = MvxUIDefine.LAYER.normal, bool resourceModel = false)
            : base(assetPath, resourceModel)
        {
            CameraName = cameraName;
            LayerName = layerName;
        }
    }
}