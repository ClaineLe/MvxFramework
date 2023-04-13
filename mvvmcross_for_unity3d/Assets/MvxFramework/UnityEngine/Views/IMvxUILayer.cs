namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUILayer : IMvxUIUnit
    {
        public int sortingLayerID { get; }
        public void AddWindow(MvxUnityWindow window);
    }
}