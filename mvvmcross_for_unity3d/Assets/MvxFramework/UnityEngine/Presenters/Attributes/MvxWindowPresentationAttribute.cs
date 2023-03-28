using MvvmCross.Presenters.Attributes;

namespace MvxFramework.UnityEngine.Presenters.Attributes
{
    public class MvxWindowPresentationAttribute : MvxBasePresentationAttribute
    {
        public string LayerName { get; }

        public MvxWindowPresentationAttribute(string layerName)
        {
            this.LayerName = layerName;
        }
    }
}