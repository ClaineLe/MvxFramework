using System.Threading.Tasks;
using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityWindow : IMvxUnityView
    {
        Task Activate(bool animated = true);
        Task Passivate(bool animated = true);
        
        Task Show(bool animated = true);
        Task Hide(bool animated = true);

        void Dismiss(bool animated = true);
    }
    
    public interface IMvxUnityWindow<TViewModel> : IMvxUnityWindow, IMvxUnityView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
    }
}