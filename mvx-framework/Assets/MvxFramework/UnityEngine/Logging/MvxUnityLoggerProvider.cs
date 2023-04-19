using Microsoft.Extensions.Logging;

namespace MvxFramework.UnityEngine.Logging
{
    public class MvxUnityLoggerProvider : ILoggerProvider
    {
        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
            => new MvxUnityLogger(categoryName);
    }
}