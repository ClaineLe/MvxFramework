using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.ViewModels;
using UnityEngine;

namespace Playground.ViewModels
{
    public class ToastParameter
    {
    }

    public class ToastViewModel : MvxUnityViewModel<ToastParameter>
    {
        public string _context;

        public string Context
        {
            get => _context;
            set => SetProperty(ref _context, value);
        }
        
        public ToastViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }

        public override void Prepare(ToastParameter parameter)
        {
            Context = "Prepare";
        }
    }
}