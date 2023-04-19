using System.Threading.Tasks;
using MvxFramework.UnityEngine.Views.Base;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityAnimationView : MvxEventSourceVisualElement
    {
        private Animation _animation;
        private Animation animation => _animation ??= transform.GetComponent<Animation>();

        protected bool CanPlayAnimation() => this.animation != null;
        
        protected async Task<bool> PlayAnimation(string animationName)
        {
            if (string.IsNullOrEmpty(animationName))
            {
                Debug.LogError($"{GetType().Name}:PlayAnimation( null )");
                return false;
            }

            var tcs = new TaskCompletionSource<bool>();
            if (animation == null)
            {
                Debug.LogError("MvxUnityAnimation: Animation component not found on " + transform.name);
                tcs.SetResult(false);
            }

            var clip = animation.GetClip(animationName);
            if (clip == null)
            {
                Debug.LogError($"{GetType().Name}:PlayAnimation({animationName})");
                return false;
            }

            animation.Play(animationName);
            await Task.Delay((int)(clip.length * 1000));//.ContinueWith(task => tcs.SetResult(true));
            return true;
        }
    }
}