using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.ViewModels;

namespace MvxFramework.UnityEngine.Services
{
    public abstract class MvxDialogViewModel : MvxUnityViewModel<DialogParameter>
    {
        public bool IsDone { get; protected set; } = false;
        public bool Result { get; protected set; } = false;

        protected DialogParameter parameter;
    
        public MvxDialogViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }

        public override void Prepare(DialogParameter parameter)
        {
            this.parameter = parameter;
        }
    }
}