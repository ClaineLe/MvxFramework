using MvxFramework.UnityEngine.Views.Base;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public static class MvxUnityUIBehaviourAdapterExtensions
    {
        public static void AdaptForBinding(this IMvxEventSourceUnityUIBehaviour view)
        {
            Debug.Log("AdaptForBinding");
            var adapter = new MvxUnityUIBehaviourAdapter(view);
            var binding = new MvxBindingUnityUIBehaviourAdapter(view);
        }
    }
}