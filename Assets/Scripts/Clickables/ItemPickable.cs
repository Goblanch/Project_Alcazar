using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickable : ClickableBase
{
    
    protected override void OnClicked()
    {
        base.OnClicked();
    }

    protected override void OnHoverStart()
    {
        base.OnHoverStart();
    }

    protected override void OnHover(Vector3 hitPoint)
    {
        base.OnHover(hitPoint);
    }

    protected override void OnHoverEnded()
    {
        base.OnHoverEnded();
    }

    protected override void OnHold()
    {
        base.OnHold();
        //transform.position = new Vector3(_lastMousePosition.x, _lastMousePosition.y, transform.position.z);
        FollowMouseMoisition();
    }

    private void FollowMouseMoisition(){
        Vector3 pos = Mouse.current.position.ReadValue();
        // This keeps object's z position value equal as where it was placed.
        pos.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }
}
