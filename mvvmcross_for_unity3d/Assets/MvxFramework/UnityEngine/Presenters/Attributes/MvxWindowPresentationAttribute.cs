using MvvmCross.Presenters.Attributes;

namespace MvxFramework.UnityEngine.Presenters.Attributes
{
    public class MvxWindowPresentationAttribute : MvxBasePresentationAttribute
    {
        public int sortingLayerId { get; }

        public MvxWindowPresentationAttribute(int sortingLayerId)
        {
            this.sortingLayerId = sortingLayerId;
        }
    }
}