using MvxFramework.UnityEngine.ViewModels;

namespace MvxFramework.UnityEngine.Services
{
    public abstract class MvxToastViewModel : MvxUnityViewModel<ToastParameter>
    {
        protected ToastParameter parameter;

        public override void Prepare(ToastParameter parameter)
        {
            this.parameter = parameter;
        }
    }
}