using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityWindow : IMvxUnityView
    {
    }
    
    public interface IMvxUnityWindow<TViewModel> : IMvxUnityWindow, IMvxUnityView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
    }
}