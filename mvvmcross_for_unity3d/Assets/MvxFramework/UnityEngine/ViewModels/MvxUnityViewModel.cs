using System.Threading.Tasks;
using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.ViewModels
{
    public abstract class MvxUnityViewModel : MvxViewModel, IMvxUnityViewModel
    {
        public Task<bool> Show(bool animated) => Task.FromResult(true);

        public Task<bool> Hide(bool animated) => Task.FromResult(true);
    }
}