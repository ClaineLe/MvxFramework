using System;
using MvvmCross.Localization;

namespace UnityEngine.Services.LocalizeService
{
    public interface IMvxLocalizeService
    {
        public EventHandler OnChangedLanguage { get; set; }

        public void RegisterLanguage(LANG lang);
        public string GetCurrentLanguage();
        public void SetLanguage(LANG language);
        public IMvxLanguageBinder GetLanguageBinder();

    }
}