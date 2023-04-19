using System.Threading.Tasks;
using MvxFramework.UnityEngine.Views.Base;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityAnimationView : MvxEventSourceVisualElement
    {
        private Animation _animation;

        protected override void Start()
        {
            base.Start();
            _animation = transform.GetComponent<Animation>();
        }

        protected async Task PlayAnimation(string animationName)
        {
            if (string.IsNullOrEmpty(animationName))
            {
                Debug.LogError($"{GetType().Namespace}:PlayAnimation( null )");
                return;
            }

            var tcs = new TaskCompletionSource<bool>();
            if (_animation == null)
            {
                Debug.LogError("MvxUnityAnimation: Animation component not found on " + _animation.name);
                tcs.SetResult(false);
            }

            var clip = _animation.GetClip(animationName);
            if (clip == null)
            {
                Debug.LogError($"{GetType().Namespace}:PlayAnimation({animationName})");
                return;
            }

            _animation.Play(animationName);
            await Task.Delay((int)clip.length * 1000).ContinueWith(task => tcs.SetResult(true));
        }
    }
}