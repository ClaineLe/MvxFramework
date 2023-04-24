using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.Services;

namespace Playground.ViewModels
{
    public class ToastViewModel : MvxToastViewModel
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
            base.Prepare(parameter);
            _context = base.parameter.Content;
        }
    }
}