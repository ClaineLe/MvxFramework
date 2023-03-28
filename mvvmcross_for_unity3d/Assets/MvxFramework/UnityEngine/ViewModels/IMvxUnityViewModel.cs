using System.Threading.Tasks;

namespace MvxFramework.UnityEngine.ViewModels
{
    public interface IMvxUnityViewModel
    {
        Task<bool> Show(bool animated);
        Task<bool> Hide(bool animated);
    }
}