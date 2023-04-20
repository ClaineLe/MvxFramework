using System.Collections.Generic;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityCameraLocator : IMvxUnityCameraLocator
    {
        protected GameObject cameraRootInstance;

        private Dictionary<string, Camera> _cameraDict = new Dictionary<string, Camera>();

        public MvxUnityCameraLocator(string assetPath = "CameraRoot")
        {
            var asset = Resources.Load<GameObject>(assetPath);
            var instance = GameObject.Instantiate(asset);
            instance.name = System.IO.Path.GetFileNameWithoutExtension(assetPath);
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