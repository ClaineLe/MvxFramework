using System;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxAnimation
    {
        IMvxAnimation OnStart(Action onStart);

        IMvxAnimation OnEnd(Action onEnd);

        IMvxAnimation Play();
    }

    public interface IMvxTransition
    {
        
    }
}