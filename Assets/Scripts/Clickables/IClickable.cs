using UnityEngine;

public interface IClickable
{
    public void OnClicked();
    public void OnHoverStarted();
    public void OnHover(Vector3 hitPoint);
    public void OnHoverEnded();

    public void OnHold(Vector2 position);
}
