using System.Threading;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using MvxFramework.UnityEngine.Presenters;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityViewDispatcher : MvxUnityMainThreadDispatcher, IMvxViewDispatcher
    {
        private readonly IMvxUnityViewPresenter _presenter;

        public MvxUnityViewDispatcher(IMvxUnityViewPresenter presenter, SynchronizationContext unitySynchronizationContext) : base(unitySynchronizationContext)
        {
            this._presenter = presenter;
        }

        public async Task<bool> ShowViewModel(MvxViewModelRequest request)
        {
            await ExecuteOnMainThreadAsync(() => _presenter.Show(request));
            return true;
        }

        public async Task<bool> ChangePresentation(MvxPresentationHint hint)
        {
            await ExecuteOnMainThreadAsync(() => _presenter.ChangePresentation(hint));
            return true;
        }
    }
}