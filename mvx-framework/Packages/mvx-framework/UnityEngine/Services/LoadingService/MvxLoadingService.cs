using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using MvxFramework.UnityEngine.Views;

namespace MvxFramework.UnityEngine.Services
{
    public class MvxLoadingService : IMvxLoadingService
    {
        private IMvxViewDispatcher _viewDispatcher;
        private IMvxViewModelLoader _viewModelLoader;

        private IMvxViewDispatcher viewDispatcher =>
            _viewDispatcher ??= Mvx.IoCProvider.Resolve<IMvxViewDispatcher>();

        private IMvxViewModelLoader viewModelLoader =>
            _viewModelLoader ??= Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();

        private MvxLoadingViewModel currViewModel;
        private bool _isLoading = false;
        public async Task ShowLoading<TViewModel>()
            where TViewModel : MvxLoadingViewModel
        {
            if(_isLoading)
                return;
            
            _isLoading = true;
            var parameter = new LoadingParameter();
            
            var viewModelType = typeof(TViewModel);
            var request = new MvxViewModelInstanceRequest(viewModelType);
            var viewModel = viewModelLoader.LoadViewModel(request, parameter, null) as MvxLoadingViewModel;
            request.ViewModelInstance = viewModel;
            await viewDispatcher.ShowViewModel(request).ConfigureAwait(false);
            if (viewModel.InitializeTask?.Task != null)
                await viewModel.InitializeTask.Task.ConfigureAwait(false);

            currViewModel = viewModel;
        }

        public async Task HideLoading()
        {
            if(_isLoading == false || currViewModel == null)
                return;
            await viewDispatcher.ChangePresentation(new MvxClosePresentationHint(currViewModel)).ConfigureAwait(false);
            _isLoading = false;
        }

        public void SetContent(string content)
        {
            currViewModel.Content = content;
        }

        public void SetProgress(float progress)
        {
            currViewModel.ProgressValue = progress;
        }
    }
}