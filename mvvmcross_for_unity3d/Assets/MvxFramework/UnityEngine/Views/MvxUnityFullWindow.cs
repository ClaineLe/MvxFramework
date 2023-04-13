using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityFullWindow<TViewModel> : MvxUnityWindow<TViewModel>, IMvxUnityFullWindow
        where TViewModel : class, IMvxViewModel
    {
        public abstract int Priority { get; }
    }
}