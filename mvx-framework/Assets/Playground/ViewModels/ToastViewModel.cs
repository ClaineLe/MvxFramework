using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.ViewModels;

namespace Playground.ViewModels
{
    public class ToastViewModel : MvxUnityViewModel
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
    }
}