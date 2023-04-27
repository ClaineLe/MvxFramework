using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvxFramework.UnityEngine.Services;

namespace Playground.ViewModels
{
    public class LoadingViewModel : MvxLoadingViewModel
    {
        private float _progress = 12.34f;
        private string _content;
        private string _progressTxt;
        
        public override float ProgressValue
        {
            get => _progress;
            set
            {
                if (SetProperty(ref _progress, value))
                {
                    TxtProgress = value.ToString("0.00%");
                }
            }
        }     
        
        public string TxtProgress
        {
            get => _progressTxt;
            set => SetProperty(ref _progressTxt, value);
        } 
        
        public override string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        } 
 
        public override void Prepare(LoadingParameter parameter)
        {
        }
    }
}