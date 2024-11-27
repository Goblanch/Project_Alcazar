using UnityEngine;

public interface IClickable
{
    public void OnClicked();
    public void OnHoverStarted();
    public void OnHover();
    public void OnHoverEnded();

    public void OnHold(Vector2 position);
}
