namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityWindowView : MvxUnityView, IMvxUnityWindowView
    {
        public IMvxAnimation ActivationAnimation { get; set; }
        public IMvxAnimation PassivationAnimation { get; set; }
    }
}