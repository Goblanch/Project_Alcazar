using System;
using UnityEngine;

public interface IClickable
{
    public event Action OnClickedEvent;
    public event Action<ClickableData> OnHoverStartEvent;
    public event Action OnHoverEvent;
    public event Action OnHoverEndEvent;
    public event Action OnHoldEvent;

    public void HandleClicked();
    public void HandleHoverStart();
    public void HandleHover(Vector3 hitPoint);
    public void HandleHoverEnd();
    public void HandleHold(Vector2 position);
}
