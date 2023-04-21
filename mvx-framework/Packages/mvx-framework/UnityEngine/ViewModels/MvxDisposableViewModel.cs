using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvxFramework.UnityEngine.ViewModels
{
    public abstract class MvxDisposableViewModel : MvxNavigationViewModel
    {
        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        protected MvxDisposableViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(
            logFactory, navigationService)
        {
        }

        ~MvxDisposableViewModel()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var disposable in _disposables)
                    disposable.Dispose();
                _disposables.Clear();
            }
        }

        protected void AddDisposable(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }

        protected void RemoveDisposable(IDisposable disposable)
        {
            _disposables.Remove(disposable);
        }
    }
}