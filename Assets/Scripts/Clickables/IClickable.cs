using UnityEngine;

public interface IClickable
{
    public void OnClicked();

    public void OnHold(Vector2 position);
}
