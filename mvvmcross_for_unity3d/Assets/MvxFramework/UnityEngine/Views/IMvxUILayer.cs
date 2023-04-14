namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUILayer 
    {
        public int sortingLayerID { get; }
        
        public void AddView(IMvxUnityView window);
    }
}