using UnityEngine;

public class ClickableBase : MonoBehaviour, IClickable
{
    public ClickableData itemData;

    private bool _isBeingHovered;
    

#region ICLICKABLE IMPLEMENTATION

    void IClickable.OnClicked()
    {
        DEBUG_LogItemInfo();
        
    }

    void IClickable.OnHoverStarted(){
        UIController.ContextMenuStartEvent?.Invoke();
        UIController.ContextMenuDataEvent?.Invoke(itemData);
    }

    void IClickable.OnHover()
    {
        _isBeingHovered = true;
        // Notify UI to show context menu with info
        UIController.ContextMenuEvent?.Invoke();
    }

    public void OnHoverEnded()
    {
        if(_isBeingHovered){
            _isBeingHovered = false;
            UIController.ContextMenuEndEvent?.Invoke();
        }
    }

    void IClickable.OnHold(Vector2 position){
        //transform.position = new Vector3(position.x, position.y, transform.position.z);
        // TODO: BUG when holded less than holdThreshold, hold keeps executing when it should be cancelled
        Debug.Log("Holding");
    }

#endregion

    private void DEBUG_LogItemInfo(){
        Debug.Log("ITEM NAME: " + itemData.name);
        Debug.Log("ITEM DESCRIPTION: " + itemData.itemDescription);
        Debug.Log("ITEM EFFECT: " + itemData.itemEffect.ToString());
    }

    
}
