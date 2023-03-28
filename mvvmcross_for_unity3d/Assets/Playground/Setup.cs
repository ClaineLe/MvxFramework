using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.Core;
using Playground.Views;

namespace Playground
{
    public class Setup : MvxUnitySetup<App>
    {
        protected virtual IMvxUnityCameraLocator CreateCameraLocator()
            => new MvxUnityCameraLocator();

        protected virtual IMvxUnityLayerLocator CreateLayerLocator(IMvxUnityCameraLocator cameraLocator)
            => new MvxUGUILayerLocator(cameraLocator);
        
        protected virtual IMvxUnityCameraLocator InitializeCameraLocator(IMvxIoCProvider iocProvider)
        {
            var cameraLocator = CreateCameraLocator();
            iocProvider.RegisterSingleton(cameraLocator);
            
            return cameraLocator;
        }

        protected virtual void InitializeLayerLocator(IMvxIoCProvider iocProvider, IMvxUnityCameraLocator cameraLocator)
        {
            var layerLocator = CreateLayerLocator(cameraLocator);
            iocProvider.RegisterSingleton(layerLocator);
        }
        
        protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
        {
            base.InitializeFirstChance(iocProvider);
            var cameraLocator = this.InitializeCameraLocator(iocProvider);
            this.InitializeLayerLocator(iocProvider, cameraLocator);
        }
    }
}