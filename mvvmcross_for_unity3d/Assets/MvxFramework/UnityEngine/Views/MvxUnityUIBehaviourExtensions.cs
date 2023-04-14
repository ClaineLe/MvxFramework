using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Exceptions;
using MvvmCross.Logging;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public static class MvxUnityUIBehaviourExtensions
    {
        public static void OnViewCreate(this IMvxUnityView iosView)
        {
            Debug.Log("OnViewCreate");
            iosView.OnViewCreate(iosView.LoadViewModel);
        }

        private static IMvxViewModel LoadViewModel(this IMvxUnityView iosView)
        {
            if (iosView.Request == null)
            {
                MvxLogHost.Default?.LogTrace(
                    "Request is null - assuming this is a TabBar type situation where ViewDidLoad is called during construction... patching the request now - but watch out for problems with virtual calls during construction");

                iosView.Request = Mvx.IoCProvider.Resolve<IMvxCurrentRequest>().CurrentRequest;
            }

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