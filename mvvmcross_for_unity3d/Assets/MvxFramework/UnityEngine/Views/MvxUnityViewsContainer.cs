using System;
using MvvmCross.Exceptions;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityViewsContainer : MvxViewsContainer, IMvxUnityViewsContainer
    {
        public MvxViewModelRequest CurrentRequest { get; private set; }

        public virtual IMvxUnityView CreateView(MvxViewModelRequest request)
        {
            try
            {
                CurrentRequest = request;
                var viewType = GetViewType(request.ViewModelType);
                if (viewType == null)
                    throw new MvxException("View Type not found for " + request.ViewModelType);

                var view = CreateViewOfType(viewType, request);
                view.Request = request;
                return view;
            }
            finally
            {
                CurrentRequest = null;
            }
        }

        public virtual IMvxUnityView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            /*
            var storyboardAttribute = viewType.GetCustomAttribute<MvxFromStoryboardAttribute>();
            if (storyboardAttribute != null)
            {
                var storyboardName = storyboardAttribute.StoryboardName ?? viewType.Name;
                try
                {
                    var storyboard = UIStoryboard.FromName(storyboardName, null);
                    var viewController = storyboard.InstantiateViewController(viewType.Name);
                    return (IMvxUnityView)viewController;
                }
                catch (Exception ex)
                {
                    throw new MvxException("Loading view of type {0} from storyboard {1} failed: {2}", viewType.Name,
                        storyboardName, ex.Message);
                }
            }
*/
            if (Activator.CreateInstance(viewType) is not IMvxUnityView view)
                throw new MvxException("View not loaded for " + viewType);
            return view;
        }

        public virtual IMvxUnityView CreateView(IMvxViewModel viewModel)
        {
            var request = new MvxViewModelInstanceRequest(viewModel);
            var view = CreateView(request);
            return view;
        }
    }
}