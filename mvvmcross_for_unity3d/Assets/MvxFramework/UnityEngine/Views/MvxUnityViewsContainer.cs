using System;
using MvvmCross.Exceptions;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public class MvxUnityViewsContainer : MvxViewsContainer, IMvxUnityViewsContainer
    {
        public virtual IMvxUnityView CreateView(MvxViewModelRequest request)
        {
            var viewType = GetViewType(request.ViewModelType);
            if (viewType == null)
                throw new MvxException("View Type not found for " + request.ViewModelType);

            var view = CreateViewOfType(viewType, request);
            return view;
        }

        public virtual IMvxUnityView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            var asset = Resources.Load<GameObject>(viewType.Name);
            var gameObject = GameObject.Instantiate(asset);
            gameObject.name = viewType.Name;
            var component = gameObject.GetComponent(viewType);
            if (component is not IMvxUnityView view)
                throw new MvxException($"View not loaded for {viewType}, gameObject:{gameObject}, component:{component}");
            view.ViewLoaded();
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