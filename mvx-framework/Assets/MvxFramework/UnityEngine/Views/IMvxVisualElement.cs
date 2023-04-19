using System;
using UnityEngine;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxVisualElement : IDisposable
    {
        public RectTransform rectTransform { get; }

        public float Alpha { get; set; }

        public bool Visible { get; set; }

        public bool Activated { get;}

        public bool Interactable { get; set; }

        void SetCanvasRenderMode(RenderMode renderMode);
        void SetCanvasCamera(Camera camera);
        void SetCanvasSortingLayer(string layerName);

    }
}