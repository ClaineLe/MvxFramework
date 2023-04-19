using System;
using Microsoft.Extensions.Logging;
using Debug = UnityEngine.Debug;

namespace MvxFramework.UnityEngine.Logging
{
    public class MvxUnityLogger : ILogger
    {
        private string _categoryName;

        public MvxUnityLogger(string categoryName)
        {
            this._categoryName = categoryName;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Information:
                case LogLevel.Critical:
                case LogLevel.None:
                    Debug.Log(formatter?.Invoke(state, exception));
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning(formatter?.Invoke(state, exception));
                    break;
                case LogLevel.Error:
                    Debug.LogError(formatter?.Invoke(state, exception));
                    break;
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}