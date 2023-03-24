using Microsoft.Extensions.Logging;

namespace MvxFramework.UnityEngine.Logging
{
    public class MvxUnityLoggerFactory : ILoggerFactory
    {
        private ILoggerProvider _provider;
        public void Dispose()
        {
            if (_provider != null)
            {
                this._provider.Dispose();
                this._provider = null;
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _provider?.CreateLogger(categoryName);
        }

        public void AddProvider(ILoggerProvider provider)
        {
            this._provider = provider;
        }
    }
}