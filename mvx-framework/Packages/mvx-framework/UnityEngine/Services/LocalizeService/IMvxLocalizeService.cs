using System.Collections.Generic;
using MvvmCross.Localization;

namespace UnityEngine.Services.LocalizeService
{
    public interface IMvxLocalizeService
    {
        public void RegisterLanguage(LANG lang);
        public string GetCurrentLanguage();
        public void SetLanguage(LANG language);
        public IMvxLanguageBinder GetLanguageBinder();

    }
}