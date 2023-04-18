using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityCameraLocator
    {
        public Camera ResolveCamera(string cameraName);

    }
}