using UnityEngine;

public abstract class ClickableBase : MonoBehaviour, IClickable
{
    public ClickableData itemData;

    protected bool _isBeingHovered;
    protected Vector3 _lastMousePosition;
    

    #region ICLICKABLE IMPLEMENTATIONs

    void IClickable.OnClicked()
    {
        OnClicked();
    }

    void IClickable.OnHoverStarted(){
        OnHoverStart();
    }

    void IClickable.OnHover(Vector3 hitPoint){
        OnHover(hitPoint);        
    }

    void IClickable.OnHoverEnded(){
        OnHoverEnded();
    }

    void IClickable.OnHold(Vector2 position){
        OnHold();
    }

    #endregion

    protected virtual void OnClicked(){
        DEBUG_LogItemInfo();
    }

    /// <summary>
    /// Called once when mouse start hovering the clickable object
    /// </summary>
    protected virtual void OnHoverStart(){
        UIController.ContextMenuStartEvent?.Invoke();
        UIController.ContextMenuDataEvent?.Invoke(itemData);
    }

    /// <summary>
    /// Called every frame mouse is hovering the clickable object
    /// </summary>
    protected virtual void OnHover(Vector3 hitPoint){
        _isBeingHovered = true;
        _lastMousePosition = hitPoint;
        // Notify UI to show context menu with info
        UIController.ContextMenuEvent?.Invoke();
    }

    /// <summary>
    /// Called once when mouse ends hovering the clickable object
    /// </summary>
    protected virtual void OnHoverEnded(){
        if(_isBeingHovered){
            _isBeingHovered = false;
            UIController.ContextMenuEndEvent?.Invoke();
        }
    }

    /// <summary>
    /// Called every frame meanwhile mouse is holding click over the clickable object
    /// </summary>
    protected virtual void OnHold(){
        // TODO: BUG when holded less than holdThreshold, hold keeps executing when it should be cancelled
        Debug.Log("Holding");
    }

    protected void DEBUG_LogItemInfo(){
        Debug.Log("ITEM NAME: " + itemData.name);
        Debug.Log("ITEM DESCRIPTION: " + itemData.itemDescription);
        Debug.Log("ITEM EFFECT: " + itemData.itemEffect.ToString());
    }

    
}
