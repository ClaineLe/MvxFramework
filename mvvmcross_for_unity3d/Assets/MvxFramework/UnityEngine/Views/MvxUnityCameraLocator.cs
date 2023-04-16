using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityCameraLocator : IMvxUnityCameraLocator
    {
        protected GameObject cameraRootInstance;
        

        public Camera GameCamera { get; protected set; }
        public Camera UIBGCamera { get; protected set; }
        public Camera UI3DCamera { get; protected set; }
        public Camera UI2DCamera { get; protected set; }
        
        public MvxUnityCameraLocator()
        {
            const string ASSET_NAME = "CameraRoot"; 
            var asset = Resources.Load<GameObject>(ASSET_NAME);
            var instance = GameObject.Instantiate(asset);
            instance.name = ASSET_NAME;
            GameObject.DontDestroyOnLoad(instance);
            cameraRootInstance = instance;

            GameCamera = instance.transform.Find("GameCamera").GetComponent<Camera>();
            UIBGCamera = instance.transform.Find("UIBGCamera").GetComponent<Camera>();
            UI3DCamera = instance.transform.Find("UI3DCamera").GetComponent<Camera>();
            UI2DCamera = instance.transform.Find("UI2DCamera").GetComponent<Camera>();

        }
    }
}