using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Services;
using MvxFramework.UnityEngine.ViewModels;
using UnityEngine;

namespace Playground.ViewModels
{
    public class SplashScreeWindowModel : MvxUnityViewModel
    {
        public IMvxCommand ClickButtonCommand { get; }
        public IMvxCommand SwitchAnimCommand { get; }

        public IMvxCommand ToastButtonCommand { get; }
        public IMvxCommand DialogButtonCommand { get; }
        public IMvxCommand LoadingButtonCommand { get; }
        
        private MvxInteraction<string> _interaction = new MvxInteraction<string>();
        public IMvxInteraction<string> Interaction => _interaction;

        private int rawImageIndex = 1;

        private string[] animNames = new[]
        {
            "Position",
            "Rotation",
            "Scale",
            "",
        };

        public SplashScreeWindowModel()
        {
            ClickButtonCommand = new MvxCommand(() =>
            {
                var navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
                navigationService.Navigate<SplashScreeViewModel>();
            });

            ToastButtonCommand = new MvxCommand(() =>
            {
                var toastService = Mvx.IoCProvider.Resolve<IMvxToastService>();
                toastService.ShowToast<ToastViewModel>("ClaineLe", 5000);
            });
            
            DialogButtonCommand = new MvxAsyncCommand(async () =>
            {
                var dialogService = Mvx.IoCProvider.Resolve<IMvxDialogService>();
                var result = await dialogService.ConfirmAsync<DialogViewModel>("内容描述", "会话框", "确认", "取消");
                Debug.Log($"Dialog.Result:{result}");
            });
            
            LoadingButtonCommand = new MvxAsyncCommand(async () =>
            {
                var loadingService = Mvx.IoCProvider.Resolve<IMvxLoadingService>();
                await loadingService.ShowLoading<LoadingViewModel>();
                
                await Task.Run(async () =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        loadingService.SetProgress(i * 0.01f);
                        await Task.Delay(17);
                    }
                    loadingService.SetProgress(1.0f);
                });
                
                await loadingService.HideLoading();
            });
            
            SwitchAnimCommand = new MvxCommand(() =>
            {
                if (++rawImageIndex >= animNames.Length)
                    rawImageIndex = 0;

                _interaction.Raise(animNames[rawImageIndex]);
            });
        }
    }
}