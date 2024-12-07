using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickable : ClickableBase
{

    protected Vector3 _initialPosition;

    protected void Start() {
        base.Start();
        _initialPosition = transform.position;
    }
    
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

    protected override void OnHoldEnd()
    {
        base.OnHoldEnd();
        // TODO: Check if object can be placed
        transform.position = _initialPosition;
    }

    private void FollowMouseMoisition(){
        Vector3 pos = Mouse.current.position.ReadValue();
        // This keeps object's z position value equal as where it was placed.
        //pos.z = transform.position.z - Camera.main.transform.position.z;
        pos.z = 3;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }
}
