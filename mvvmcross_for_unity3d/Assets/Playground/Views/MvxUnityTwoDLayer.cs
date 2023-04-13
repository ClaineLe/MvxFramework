using System.Collections.Generic;

namespace Playground.Views
{
    public class MvxUnityTwoDLayer : MvxUnityLayer
    {
        private Dictionary<int, int> dict = new Dictionary<int, int>();
        
        public MvxUnityTwoDLayer()
        {
            dict.Add(UIPriority.normal, UIPriority.normal);
            dict.Add(UIPriority.plot, UIPriority.plot);
            dict.Add(UIPriority.guide, UIPriority.guide);
            dict.Add(UIPriority.top, UIPriority.top);
            dict.Add(UIPriority.loading, UIPriority.loading);
            dict.Add(UIPriority.system, UIPriority.system);
        }
    }
}