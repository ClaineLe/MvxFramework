using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityCameraLocator
    {
        public Camera GameCamera { get; }
        public Camera UIBGCamera { get; }
        public Camera UI3DCamera { get; }
        public Camera UI2DCamera { get; }
    }
}