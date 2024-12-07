using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputListener input;

    private bool _mouseHold;
    private bool _mouseHoldCancelled;
    private bool _mouseHoldTimerEnd;
    private IClickable _currentHovered;
    private IClickable _lastClickable;
    private IClickable _lastClickableInteracted;

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
        MouseHold();
        InfoRay();
    }

    public void HandleClick(){


        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hitInfo;

        // Raycast from mouse
        if(Physics.Raycast(ray, out hitInfo)){
            if(hitInfo.collider.gameObject.TryGetComponent<IClickable>(out IClickable clickable)){
                _lastClickable = clickable;
                _lastClickableInteracted = clickable;
                clickable.HandleClicked();
            }
        }
    }

    public void HandleStartMouseHold(){
        _mouseHoldTimerEnd = false;
        StartCoroutine(MouseHoldTimer());
    }

    public void MouseHold(){
        if(_mouseHold && _lastClickableInteracted != null){
            _lastClickableInteracted.HandleHold(Vector2.up);
        }
    }

    private IEnumerator MouseHoldTimer(){
        yield return new WaitForSeconds(input.clickHoldTime);
        _mouseHoldTimerEnd = true;
        if(!_mouseHoldCancelled){
            _mouseHold = true;            
        }else{
            _mouseHoldCancelled = false;
        }
    }

    public void HandleEndMouseHold(){
        _mouseHold = false;
        if(!_mouseHoldTimerEnd){
            _mouseHoldCancelled = true;
        }

        if(_lastClickable != null) _lastClickable.HandleHoldEnd();
    }

    private void InfoRay(){
        if(_mouseHold) return;
        Debug.Log("INFORAY");
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo)){
            IClickable hovered = hitInfo.collider.gameObject.GetComponent<IClickable>();

            // HOVER START
            if(_lastClickable != hovered && hovered != null){
                hovered.HandleHoverStart();
            }

            // HOVERING
            if(hovered != null){
                hovered.HandleHover(hitInfo.point);
                _lastClickable = hovered;
            }
        }else{
            // HOVER ENDED
            if(_lastClickable != null){
                _lastClickable.HandleHoverEnd();
                _lastClickable = null;
            }
        }
    }
}
