using MvvmCross.Presenters.Attributes;

namespace MvxFramework.UnityEngine.Presenters.Attributes
{
    public class MvxWindowPresentationAttribute : MvxBasePresentationAttribute
    {
        //public string Identifier { get; }
        //public int priority { get; }
        public string CameraName { get; }

        public string LayerName { get; }

        public MvxWindowPresentationAttribute(string cameraName, string layerName)
        {
            CameraName = cameraName;
            LayerName = layerName;
        }
    }
}