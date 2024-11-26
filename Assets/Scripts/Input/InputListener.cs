using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InputListener", menuName = "Scriptable Objects/InputListener")]
public class InputListener : ScriptableObject, PlayerInput.IPlayerActions, PlayerInput.IUIActions
{

    public enum GameModes{
        Game, UI
    }

    public float clickHoldTime = .5f;

    public Action ClickEvent;
    public Action MouseStartHoldEvent;
    public Action MouseEndHoldEvent;
    public Action PauseEvent;
    public Action ResumeEvent;

    private PlayerInput _pInput;

    private void OnEnable() {
        if(_pInput == null){
            _pInput = new PlayerInput();

            _pInput.UI.SetCallbacks(this);
            _pInput.Player.SetCallbacks(this);

            ChangeGameMode(GameModes.Game);
        }
    }

    private void OnDisable() {
        _pInput.UI.Disable();
        _pInput.Player.Disable();
    }

    public void ChangeGameMode(GameModes gMod){
        switch(gMod){
            case GameModes.Game:
                _pInput.Player.Enable();
                _pInput.UI.Disable();
                break;

            case GameModes.UI:
                _pInput.UI.Enable();
                _pInput.Player.Disable();
                break;
        }
    }

#region INTERFACES IMPLEMENTATIONS
    public void OnLeftClick(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.phase == UnityEngine.InputSystem.InputActionPhase.Performed){
            ClickEvent?.Invoke();
        }

    }

    public void OnMouseHold(UnityEngine.InputSystem.InputAction.CallbackContext context){
        if(context.phase == UnityEngine.InputSystem.InputActionPhase.Performed){
            MouseStartHoldEvent?.Invoke();
        }

        if(context.phase == UnityEngine.InputSystem.InputActionPhase.Canceled){
            MouseEndHoldEvent?.Invoke();
        }
    }

    public void OnPauseGame(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.phase == UnityEngine.InputSystem.InputActionPhase.Performed){
            PauseEvent?.Invoke();
        }
    }

    public void OnResumeGame(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.phase == UnityEngine.InputSystem.InputActionPhase.Performed){
            ResumeEvent?.Invoke();
        }
    }

#endregion
}
