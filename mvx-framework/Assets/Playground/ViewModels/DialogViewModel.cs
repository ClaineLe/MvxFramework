using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.Services;

namespace Playground.ViewModels
{
    public class DialogViewModel : MvxDialogViewModel
    {
        public string _title;
        public string _content;

        public string _confirm;
        public string _cancel;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public string Confirm
        {
            get => _confirm;
            set => SetProperty(ref _confirm, value);
        }

        public string Cancel
        {
            get => _cancel;
            set => SetProperty(ref _cancel, value);
        }

        public IMvxCommand ConfirmCommand { get; }
        public IMvxCommand CancelCommand { get; }

        public DialogViewModel()
        {
            ConfirmCommand = new MvxCommand(() =>
            {
                this.Result = true;
                this.IsDone = true;
            });

            CancelCommand = new MvxCommand(() =>
            {
                this.Result = false;
                this.IsDone = true;
            });
        }

        public override void Prepare(DialogParameter parameter)
        {
            base.Prepare(parameter);
            this.Title = base.parameter.Title;
            this.Content = base.parameter.Content;
            this.Confirm = base.parameter.ConfirmLabel;
            this.Cancel = base.parameter.CancelLabel;
        }
    }
}