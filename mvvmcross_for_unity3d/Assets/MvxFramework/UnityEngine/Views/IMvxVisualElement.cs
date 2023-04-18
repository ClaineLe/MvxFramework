using System;
using UnityEngine;
using UnityEngine.UI;

namespace MvxFramework.UnityEngine.Views
{
    public interface IMvxVisualElement : IDisposable
    {
        public RectTransform rectTransform { get; }
        public Canvas canvas{ get; }
        public CanvasGroup canvasGroup{ get; }
        public GraphicRaycaster graphicRaycaster{ get; }
    }
}