using System;
using System.Collections.Generic;
using System.Globalization;
using MvvmCross;
using MvvmCross.Localization;
using MvvmCross.Plugin.JsonLocalization;
using MvvmCross.Plugin.Messenger;
using UnityEngine.Messages;

namespace UnityEngine.Services.LocalizeService
{
    public class MvxLocalizeService : IMvxLocalizeService
    {
        internal class MvxLanguage
        {
            public string Name { get; protected set; }
            public LANG lang { get; protected set; }
            public CultureInfo cultureInfo { get; protected set; }
            public IMvxLanguageBinder textSource { get; protected set; }

            public MvxLanguage(string generalNamespace, LANG lang)
            {
                this.Name = lang.ToString();
                this.lang = lang;
                this.cultureInfo = new CultureInfo(Name.Replace('_', '-'));
                this.textSource = new MvxLanguageBinder(generalNamespace, Name);
            }
        }
        
        private static readonly Dictionary<LANG, MvxLanguage> _supportedLanguages = new ();

        private IMvxTextProviderBuilder _builder;
        protected IMvxTextProviderBuilder builder => Mvx.IoCProvider.Resolve<IMvxTextProviderBuilder>();

        
        public LANG currentLanguage;
        
        public List<LANG> GetSupportedLanguages() => new (_supportedLanguages.Keys);

        private string generalNamespace { get; }
        protected IMvxMessenger messenger => Mvx.IoCProvider.Resolve<IMvxMessenger>();

        public MvxLocalizeService(string generalNamespace)
        {
            this.generalNamespace = generalNamespace;
        }

        public void RegisterLanguage(LANG lang)
        {
            if(_supportedLanguages.TryGetValue(lang, out var _))
                return;
            _supportedLanguages.Add(lang, new MvxLanguage(generalNamespace, lang));
        }

        public string GetCurrentLanguage()
        {
            return _supportedLanguages.ContainsKey(currentLanguage) ? currentLanguage.ToString() : "NULL";
        }

        public void SetLanguage(LANG language)
        {
            if (_supportedLanguages.TryGetValue(language, out var _) == false)
                throw new NotSupportedException($"当前语言未注册:{language}");

            currentLanguage = language;
            builder.LoadResources(language.ToString());
            
            messenger.Publish(new LanguageChangedMessage(this));
        }

        public IMvxLanguageBinder GetLanguageBinder()
        {
            return _supportedLanguages.TryGetValue(currentLanguage, out var language) ? language.textSource : null;
        }
    }
}