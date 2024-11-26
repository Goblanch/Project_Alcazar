using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputListener input;

    private bool _mouseHold;
    private IClickable _lastClickable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input.ClickEvent            += HandleClick;
        input.MouseStartHoldEvent   += HandleStartMouseHold;
        input.MouseEndHoldEvent     += HandleEndMouseHold;
    }

    private void Update() {
        if(_mouseHold && _lastClickable != null){
            _lastClickable.OnHold(Vector2.up);
        }
    }

    public void HandleClick(){
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hitInfo;

        // Raycast from mouse
        if(Physics.Raycast(ray, out hitInfo)){
            _lastClickable = hitInfo.collider.gameObject.GetComponent<IClickable>();
            if(_lastClickable != null){
                _lastClickable.OnClicked();
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
}
