using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using MvxFramework.UnityEngine.Views;

namespace MvxFramework.UnityEngine.Services
{
    public class MvxDialogService : IMvxDialogService
    {
        private IMvxViewDispatcher _viewDispatcher;
        private IMvxViewModelLoader _viewModelLoader;

        private IMvxViewDispatcher viewDispatcher =>
            _viewDispatcher ??= Mvx.IoCProvider.Resolve<IMvxViewDispatcher>();

        private IMvxViewModelLoader viewModelLoader =>
            _viewModelLoader ??= Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();
        
        public async Task<bool> ConfirmAsync<TViewModel>(string message, string title, string btnConfirmLabel, string btnCancelLabel)
            where TViewModel : MvxDialogViewModel
        {
            var parameter = new DialogParameter
            {
                Content = message,
                Title = title,
                ConfirmLabel = btnConfirmLabel,
                CancelLabel = btnCancelLabel
            };
            
            var viewModelType = typeof(TViewModel);
            var request = new MvxViewModelInstanceRequest(viewModelType);
            var viewModel = viewModelLoader.LoadViewModel(request, parameter, null) as MvxDialogViewModel;
            request.ViewModelInstance = viewModel;
            await viewDispatcher.ShowViewModel(request).ConfigureAwait(false);
            if (viewModel.InitializeTask?.Task != null)
                await viewModel.InitializeTask.Task.ConfigureAwait(false);

            await MvxTaskUtil.WaitUntil(() => viewModel.IsDone);
            var result = viewModel.Result;
            await viewDispatcher.ChangePresentation(new MvxClosePresentationHint(viewModel)).ConfigureAwait(false);
            return result;
        }
    }
}