using MvxFramework.UnityEngine.Views.Base;

namespace MvxFramework.UnityEngine.Views
{
    public static class MvxVisualElementAdapterExtensions
    {
        public static void AdaptForBinding(this IMvxEventSourceVisualElement view)
        {
            var adapter = new MvxVisualElementAdapter(view);
            var binding = new MvxBindingVisualElementAdapter(view);
        }
    }
}