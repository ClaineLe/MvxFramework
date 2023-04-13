using MvvmCross.Presenters.Attributes;

namespace MvxFramework.UnityEngine.Presenters.Attributes
{
    public class MvxWindowPresentationAttribute : MvxBasePresentationAttribute
    {
        public string layerName { get; }
        public int priority { get; }

        public MvxWindowPresentationAttribute(string layerName, int priority = 0)
        {
            this.layerName = layerName;
            this.priority = priority;
        }
    }
}