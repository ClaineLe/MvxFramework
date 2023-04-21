using System.Collections.Generic;
using MvvmCross;
using MvvmCross.Plugin.JsonLocalization;
using UnityEngine.Services.LocalizeService;

namespace UnityEngine.Services.LocalizeService
{
    public class TextProviderBuilder
        : MvxTextProviderBuilder
    {
        private string currentLanguage => Mvx.IoCProvider.Resolve<IMvxLocalizeService>().GetCurrentLanguage();
        public TextProviderBuilder(string generalNamespace, string rootFolderForResources) : base(generalNamespace, rootFolderForResources)
        {
        }

        protected override IDictionary<string, string> ResourceFiles => new Dictionary<string, string>
        {
            [currentLanguage] = currentLanguage
        };

        protected override string GetResourceFilePath(string whichLocalizationFolder, string whichFile)
            => $"{_rootFolderForResources}/{whichFile}.json";
    }
}