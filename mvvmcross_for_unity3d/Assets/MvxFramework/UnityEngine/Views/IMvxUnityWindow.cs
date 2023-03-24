using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityWindow : IMvxView
    {
    }
    
    public interface IMvxUnityWindow<TViewModel> : IMvxUnityWindow, IMvxView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
    }
}