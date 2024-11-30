using UnityEngine;

public abstract class ClickableBase : MonoBehaviour, IClickable
{
    public ClickableData itemData;

    protected bool _isBeingHovered;
    

#region ICLICKABLE IMPLEMENTATION

    void IClickable.OnClicked()
    {
        DEBUG_LogItemInfo();
        
    }

    void IClickable.OnHoverStarted(){
        OnHoverStart();
    }

    void IClickable.OnHover(){
        OnHover();        
    }

    void IClickable.OnHoverEnded(){
        OnHoverEnded();
    }

    void IClickable.OnHold(Vector2 position){
        OnHold();
    }

#endregion

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
    protected virtual void OnHover(){
        _isBeingHovered = true;
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
        //transform.position = new Vector3(position.x, position.y, transform.position.z);
        // TODO: BUG when holded less than holdThreshold, hold keeps executing when it should be cancelled
        Debug.Log("Holding");
    }

    protected void DEBUG_LogItemInfo(){
        Debug.Log("ITEM NAME: " + itemData.name);
        Debug.Log("ITEM DESCRIPTION: " + itemData.itemDescription);
        Debug.Log("ITEM EFFECT: " + itemData.itemEffect.ToString());
    }

    
}
