using MvxFramework.UnityEngine.Views.Base;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public static class MvxVisualElementAdapterExtensions
    {
        public static void AdaptForBinding(this IMvxEventSourceVisualElement view)
        {
            Debug.Log("AdaptForBinding");
            var adapter = new MvxVisualElementAdapter(view);
            var binding = new MvxBindingVisualElementAdapter(view);
        }
    }
}