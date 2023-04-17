using MvvmCross.Presenters.Attributes;

namespace MvxFramework.UnityEngine.Presenters.Attributes
{
    public class MvxWindowPresentationAttribute : MvxBasePresentationAttribute
    {
        public string Identifier { get; }
        public int priority { get; }

        public MvxWindowPresentationAttribute(string Identifier, int priority = 0)
        {
            this.Identifier = Identifier;
            this.priority = priority;
        }
    }
}