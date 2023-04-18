using System.Collections.Generic;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityCameraLocator : IMvxUnityCameraLocator
    {
        protected GameObject cameraRootInstance;

        private Dictionary<string, Camera> _cameraDict = new Dictionary<string, Camera>();

        public MvxUnityCameraLocator()
        {
            const string ASSET_NAME = "CameraRoot"; 
            var asset = Resources.Load<GameObject>(ASSET_NAME);
            var instance = GameObject.Instantiate(asset);
            instance.name = ASSET_NAME;
            GameObject.DontDestroyOnLoad(instance);
            cameraRootInstance = instance;

            RegisterCamera(MvxUIDefine.CAM.game);
            RegisterCamera(MvxUIDefine.CAM.backGround);
            RegisterCamera(MvxUIDefine.CAM.threeD);
            RegisterCamera(MvxUIDefine.CAM.twoD);
        }

        private void RegisterCamera(string cameraName)
        {
            _cameraDict.Add(cameraName, cameraRootInstance.transform.Find(cameraName).GetComponent<Camera>());
        }

        public Camera ResolveCamera(string cameraName)
        {
            if (_cameraDict.TryGetValue(cameraName, out var camera) == false)
                return null;
            return camera;
        }
    }
}