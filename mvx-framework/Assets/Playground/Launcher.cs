using System.Threading.Tasks;
using MvxFramework.UnityEngine.Core;

namespace Playground
{
    public class Launcher : MvxLauncher<Setup>
    {
        private async Task Start()
        {
            await SetupStart();
        }
    }
}