using System;
using MvvmCross.Base;
using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Views;
using Playground.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Playground.Views
{
    public class SplashScreenWindow : MvxUnityWindow<SplashScreeWindowModel>
    {
        public Button ClickButton;
        public Button AnimButton;

        public Button BtnToast;
        public Button BtnDialogBox;
        public Button BtnLoading;
        
        public Text LanguageTextOneWay;
        public Text LanguageTextOneTime;

        private IMvxInteraction<string> _interaction;

        public IMvxInteraction<string> Interaction
        {
            get => _interaction;
            set
            {
                if (_interaction != null)
                    _interaction.Requested -= OnInteractionRequested;

                _interaction = value;
                _interaction.Requested += OnInteractionRequested;
            }
        }

        protected override void OnViewLoaded()
        {
            var setter = CreateBindingSet();
            setter.Bind(this.ClickButton).To(vm => vm.ClickButtonCommand);
            setter.Bind(this.AnimButton).To(vm => vm.SwitchAnimCommand);
            
            setter.Bind(this.BtnToast).To(vm => vm.ToastButtonCommand);
            setter.Bind(this.BtnDialogBox).To(vm => vm.DialogButtonCommand);
            setter.Bind(this.BtnLoading).To(vm => vm.LoadingButtonCommand);
            
            setter.Bind(this).For(view => view.Interaction).To(viewModel => viewModel.Interaction).OneWay();
            setter.Apply();
            
            this.BindLanguage(LanguageTextOneTime, "text", "ExampleText");
            this.BindLanguage(LanguageTextOneWay, "text", "ExampleText", bindingMode: MvxBindingMode.OneWay);
        }

        private void OnInteractionRequested(object sender, MvxValueEventArgs<string> eventArgs)
        {
            var task = PlayAnimation(eventArgs.Value);
        }
    }
}