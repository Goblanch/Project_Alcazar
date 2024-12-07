using UnityEngine;
using System;

public abstract class ClickableBase : MonoBehaviour, IClickable
{
    public ClickableData itemData;

    protected bool _isBeingHovered;
    protected Vector3 _lastMousePosition;
    
    public void ConfigureClickable(){
        ServiceLocator.Instance.GetService<UIMediator>().SetupObservers(this);
    }

    protected void Start() {
        ConfigureClickable();
    }

    #region ICLICKABLE IMPLEMENTATIONs

    public event Action OnClickedEvent;
    public event Action<ClickableData> OnHoverStartEvent;
    public event Action OnHoverEvent;
    public event Action OnHoverEndEvent;
    public event Action OnHoldEvent;
    public event Action OnHoldEndEvent;

    void IClickable.HandleClicked(){
        OnClicked();
        OnClickedEvent?.Invoke();
    }

    void IClickable.HandleHoverStart(){
        OnHoverStart();
        OnHoverStartEvent?.Invoke(itemData);
    }

    void IClickable.HandleHover(Vector3 hitPoint){
        OnHover(hitPoint); 
        OnHoverEvent?.Invoke();       
    }

    void IClickable.HandleHoverEnd(){
        OnHoverEnded();
        OnHoverEndEvent?.Invoke();
    }

    void IClickable.HandleHold(Vector2 position){
        OnHold();
        OnHoldEvent?.Invoke();
    }

    void IClickable.HandleHoldEnd(){
        OnHoldEnd();
        OnHoldEndEvent?.Invoke();
    }

    #endregion

    protected virtual void OnClicked(){
        DEBUG_LogItemInfo();
    }

    /// <summary>
    /// Called once when mouse start hovering the clickable object
    /// </summary>
    protected virtual void OnHoverStart(){}

    /// <summary>
    /// Called every frame mouse is hovering the clickable object
    /// </summary>
    protected virtual void OnHover(Vector3 hitPoint){
        _isBeingHovered = true;
        _lastMousePosition = hitPoint;
    }

    /// <summary>
    /// Called once when mouse ends hovering the clickable object
    /// </summary>
    protected virtual void OnHoverEnded(){
        if(_isBeingHovered){
            _isBeingHovered = false;
        }
    }

    /// <summary>
    /// Called every frame meanwhile mouse is holding click over the clickable object
    /// </summary>
    protected virtual void OnHold(){
        // TODO: BUG when holded less than holdThreshold, hold keeps executing when it should be cancelled
        Debug.Log("Holding");
    }

    protected virtual void OnHoldEnd(){}

    protected void DEBUG_LogItemInfo(){
        Debug.Log("ITEM NAME: " + itemData.name);
        Debug.Log("ITEM DESCRIPTION: " + itemData.itemDescription);
        Debug.Log("ITEM EFFECT: " + itemData.itemEffect.ToString());
    }

    
}
