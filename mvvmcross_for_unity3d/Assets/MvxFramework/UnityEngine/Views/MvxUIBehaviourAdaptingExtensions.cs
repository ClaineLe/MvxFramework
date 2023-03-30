using MvxFramework.UnityEngine.Views.Base;

namespace MvxFramework.UnityEngine.Views
{
    public static class MvxUIBehaviourAdaptingExtensions
    {
        public static void AdaptForBinding(this IMvxEventSourceUIBehaviour view)
        {
            var adapter = new MvxUIBehaviourAdapter(view);
            var binding = new MvxUIBehaviourBindingAdapter(view);
        }
    }
}