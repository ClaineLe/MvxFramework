using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Views.Base;

namespace MvxFramework.UnityEngine.Views
{
    public abstract class MvxUnityView : MvxEventSourceUIBehaviour, IMvxUnityView
    {
        public object DataContext
        {
            get => BindingContext.DataContext;
            set => BindingContext.DataContext = value;
        }
        public IMvxViewModel ViewModel
        {
            get => DataContext as IMvxViewModel;
            set => DataContext = value;
        }
        
        public IMvxBindingContext BindingContext { get; set; }

        public virtual void ViewLoaded()
        {
            ViewModel.ViewCreated();
        }

        public MvxViewModelRequest Request { get; set; }

    }

    public class MvxUnityView<TViewModel> : MvxUnityView, IMvxUnityView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        public MvxFluentBindingDescriptionSet<IMvxUnityView<TViewModel>, TViewModel> CreateBindingSet()
        {
            return this.CreateBindingSet<IMvxUnityView<TViewModel>, TViewModel>();
        }

        public new TViewModel ViewModel
        {
            get => base.ViewModel as TViewModel;
            set => base.ViewModel = value;
        }
    }
}