using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace MvxFramework.UnityEngine.Services
{
    public class MvxToastService : IMvxToastService
    {
        private IMvxViewDispatcher _viewDispatcher;
        private IMvxViewModelLoader _viewModelLoader;

        private IMvxViewDispatcher viewDispatcher =>
            _viewDispatcher ??= Mvx.IoCProvider.Resolve<IMvxViewDispatcher>();

        private IMvxViewModelLoader viewModelLoader =>
            _viewModelLoader ??= Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();
        
        public async Task<bool> ShowToast<TViewModel>(string message, int duration)
            where TViewModel : MvxToastViewModel
        {
            var parameter = new ToastParameter()
            {
                Content = message
            };
            var viewModelType = typeof(TViewModel);
            var request = new MvxViewModelInstanceRequest(viewModelType);
            var viewModel = viewModelLoader.LoadViewModel(request, parameter, null);
            request.ViewModelInstance = viewModel;
            await viewDispatcher.ShowViewModel(request).ConfigureAwait(false);
            if (viewModel.InitializeTask?.Task != null)
                await viewModel.InitializeTask.Task.ConfigureAwait(false);

            await Task.Delay(duration);
            
            return await viewDispatcher.ChangePresentation(new MvxClosePresentationHint(viewModel)).ConfigureAwait(false);
        }
    }
}