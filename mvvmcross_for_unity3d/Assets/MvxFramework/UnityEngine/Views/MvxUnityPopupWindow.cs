using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityPopupWindow<TViewModel> : MvxUnityWindow<TViewModel>,IMvxUnityPopupWindow
        where TViewModel : class, IMvxViewModel
    {
    }
}