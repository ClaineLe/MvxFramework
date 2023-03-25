using MvvmCross;
using MvvmCross.Exceptions;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace MvxFramework.UnityEngine.Views
{
    public static class MvxUIBehaviourExtensions
    {
        public static void OnViewCreate(this IMvxUnityView iosView)
        {
            iosView.OnViewCreate(iosView.LoadViewModel);
        }

        private static IMvxViewModel LoadViewModel(this IMvxUnityView iosView)
        {
            if (iosView.Request is MvxViewModelInstanceRequest instanceRequest)
            {
                return instanceRequest.ViewModelInstance;
            }

            var loader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();
            var viewModel = loader.LoadViewModel(iosView.Request, null /* no saved state on iOS currently */);
            if (viewModel == null)
                throw new MvxException("ViewModel not loaded for " + iosView.Request.ViewModelType);
            return viewModel;
        }
    }
}