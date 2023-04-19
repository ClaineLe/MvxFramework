using System;
using MvvmCross.Base;
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

        public Image BackGround;

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
            setter.Bind(this).For(view => view.Interaction).To(viewModel => viewModel.Interaction).OneWay();
            setter.Apply();
        }

        private void OnInteractionRequested(object sender, MvxValueEventArgs<string> eventArgs)
        {
            var task = PlayAnimation(eventArgs.Value);
        }
    }
}