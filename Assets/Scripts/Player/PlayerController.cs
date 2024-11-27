using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputListener input;

    private bool _mouseHold;
    private IClickable _currentHovered;
    private IClickable _lastClickable;

    private void OnEnable() {
        input.ClickEvent            += HandleClick;
        input.MouseStartHoldEvent   += HandleStartMouseHold;
        input.MouseEndHoldEvent     += HandleEndMouseHold;
    }

    private void OnDisable(){
        input.ClickEvent            -= HandleClick;
        input.MouseStartHoldEvent   -= HandleStartMouseHold;
        input.MouseEndHoldEvent     -= HandleEndMouseHold;
    }

    private void Update() {
        if(_mouseHold && _lastClickable != null){
            _lastClickable.OnHold(Vector2.up);
        }

        InfoRay();
    }

    public void HandleClick(){
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hitInfo;

        // Raycast from mouse
        if(Physics.Raycast(ray, out hitInfo)){
            if(hitInfo.collider.gameObject.TryGetComponent<IClickable>(out IClickable clickable)){
                _lastClickable = clickable;
                clickable.OnClicked();
            }
        }
    }

    public void HandleStartMouseHold(){
        StartCoroutine(MouseHoldTimer());
    }

    private IEnumerator MouseHoldTimer(){
        yield return new WaitForSeconds(input.clickHoldTime);
        _mouseHold = true;
    }

    public void HandleEndMouseHold(){
        _mouseHold = false;
    }

    private void InfoRay(){
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo)){
            IClickable hovered = hitInfo.collider.gameObject.GetComponent<IClickable>();

            // HOVER START
            if(_lastClickable != hovered && hovered != null){
                hovered.OnHoverStarted();
            }

            // HOVERING
            if(hovered != null){
                hovered.OnHover();
                _lastClickable = hovered;
            }
        }else{
            // HOVER ENDED
            if(_lastClickable != null){
                _lastClickable.OnHoverEnded();
                _lastClickable = null;
            }
        }
    }
}
