using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonBase : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler,
    IPointerDownHandler, IPointerUpHandler
{
    public bool IsClicked { get; private set; } = false;
    public UnityEvent OnClick;
    public UnityEvent OnRightClick;
    public UnityEvent OnMouseDown;
    public UnityEvent OnMouseUp;
    public UnityEvent OnMouseEnter;
    public UnityEvent OnMouseExit;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsClicked) { return; }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnClick?.Invoke();
        }

        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick?.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnMouseDown?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseExit?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnMouseUp?.Invoke();
    }

    public void SetClicked(bool value)
    {
        IsClicked = value;
    }
}