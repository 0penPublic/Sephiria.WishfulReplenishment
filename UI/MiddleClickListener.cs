using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WishfulReplenishment
{
    public class MiddleClickListener : MonoBehaviour, IPointerClickHandler
    {
        public Action? onMiddleClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Middle)
            {
                onMiddleClick?.Invoke();
            }
        }
    }
}
