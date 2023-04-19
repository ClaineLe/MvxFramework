using System;
using System.Threading.Tasks;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    internal class MvxTaskUtil
    {
        public static async Task WaitUntil(Func<bool> predicate, int sleep = 17)
        {
            while (!predicate())
            {
                await Task.Delay(sleep);
            }
        }

        /// <summary>
        /// 方法：等待X帧
        /// </summary>
        /// <returns>Task</returns>
        public static async Task WaitFrame(int count)
        {
            var current = Time.frameCount;
            while (Time.frameCount - current > count)
            {
                await Task.Yield();
            }
        }

        /// <summary>
        /// 方法：等待X帧
        /// </summary>
        /// <returns>Task</returns>
        public static async Task DelayFrame(int count)
        {
            var current = Time.frameCount;
            while (Time.frameCount - current > count)
            {
                await Task.Yield();
            }
        }
    }
}