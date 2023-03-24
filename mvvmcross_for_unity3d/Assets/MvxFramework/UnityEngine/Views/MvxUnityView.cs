using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using UnityEngine.EventSystems;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityView : UIBehaviour, IMvxUnityView
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