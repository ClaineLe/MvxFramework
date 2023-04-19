using System;
using MvvmCross.Exceptions;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
 
    public class MvxUnityViewsContainer : MvxViewsContainer, IMvxUnityViewCreator
    {
        public MvxViewModelRequest CurrentRequest { get; private set; }

        public virtual IMvxVisualElement CreateView(MvxViewModelRequest request)
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
            var asset = Resources.Load<GameObject>(viewType.Name);
            var gameObject = GameObject.Instantiate(asset);
            gameObject.name = viewType.Name;
            var component = gameObject.GetComponent(viewType);
            if (component is not IMvxUnityView view)
                throw new MvxException($"View not loaded for {viewType}, gameObject:{gameObject}, component:{component}");
            return view;
        }

        public virtual IMvxVisualElement CreateView(IMvxViewModel viewModel)
        {
            var request = new MvxViewModelInstanceRequest(viewModel);
            return CreateView(request);
        }
    }
}