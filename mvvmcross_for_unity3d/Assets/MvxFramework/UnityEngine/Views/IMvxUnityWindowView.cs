namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxUnityWindowView
    {
        /// <summary>
        /// Activation animation
        /// </summary>
        IMvxAnimation ActivationAnimation { get; set; }

        /// <summary>
        /// Passivation animation
        /// </summary>
        IMvxAnimation PassivationAnimation { get; set; }
    }
}