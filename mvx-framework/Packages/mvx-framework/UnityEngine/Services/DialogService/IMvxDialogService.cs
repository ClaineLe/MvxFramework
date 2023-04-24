using System.Threading.Tasks;

namespace MvxFramework.UnityEngine.Services
{
    public interface IMvxDialogService
    {
        Task<bool> ConfirmAsync<TViewModel>(string message, string title, string btnConfirmLabel,
            string btnCancelLabel)
            where TViewModel : MvxDialogViewModel;
    }
}