using MvxFramework.UnityEngine.Services;
using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;
using UnityEngine.UI;

namespace Playground.Views
{
    public class DialogView : MvxUnityView<DialogViewModel>
    {
        public Image BackGround;
        public Text Title;
        public Text Content;
        public Button BtnConfirm;
        public Button BtnCancel;

        public Text ConfirmLabel;
        public Text CancelLabel;

        protected override void OnViewLoaded()
        {
            var setter = CreateBindingSet();
            
            setter.Bind(Title).To(vm => vm.Title);
            setter.Bind(Content).To(vm => vm.Content);

            setter.Bind(BtnConfirm).To(vm => vm.ConfirmCommand);
            setter.Bind(BtnCancel).To(vm => vm.CancelCommand);
            
            setter.Bind(ConfirmLabel).To(vm => vm.Confirm);
            setter.Bind(CancelLabel).To(vm => vm.Cancel);
            
            setter.Apply();
        }
    }
}