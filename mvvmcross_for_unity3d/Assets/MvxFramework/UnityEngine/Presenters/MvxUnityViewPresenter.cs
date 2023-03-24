using System;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;

namespace MvxFramework.UnityEngine.Presenters
{
    public class MvxUnityViewPresenter :MvxAttributeViewPresenter, IMvxUnityViewPresenter
    {
        public override void RegisterAttributeTypes()
        {
        }

        public override MvxBasePresentationAttribute CreatePresentationAttribute(Type viewModelType, Type viewType)
        {
            return default;
        }
    }
}