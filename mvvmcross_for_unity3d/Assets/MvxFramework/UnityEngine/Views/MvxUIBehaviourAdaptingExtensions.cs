using MvxFramework.UnityEngine.Views.Base;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public static class MvxUIBehaviourAdaptingExtensions
    {
        public static void AdaptForBinding(this IMvxEventSourceUIBehaviour view)
        {
            Debug.Log("AdaptForBinding");
            var adapter = new MvxUIBehaviourAdapter(view);
            var binding = new MvxUIBehaviourBindingAdapter(view);
        }
    }
}