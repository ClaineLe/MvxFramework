using MvvmCross.Presenters.Attributes;

namespace MvxFramework.UnityEngine.Presenters.Attributes
{
    public abstract class MvxUnityBasePresentationAttribute : MvxBasePresentationAttribute
    {
        public bool ResourceModel { get; }
        public string AssetPath { get; }

        public MvxUnityBasePresentationAttribute(string assetPath, bool resourceModel)
        {
            this.AssetPath = assetPath;
            this.ResourceModel = resourceModel;
        }
    }
}