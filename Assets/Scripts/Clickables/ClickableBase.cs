using UnityEngine;

public class ClickableBase : MonoBehaviour, IClickable
{
    public ClickableData itemData;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IClickable.OnClicked()
    {
        DEBUG_LogItemInfo();
        UIController.sampleTextEvent?.Invoke(itemData);
    }

    void IClickable.OnHold(Vector2 position){
        //transform.position = new Vector3(position.x, position.y, transform.position.z);
        Debug.Log("Holding");
    }

    private void DEBUG_LogItemInfo(){
        Debug.Log("ITEM NAME: " + itemData.name);
        Debug.Log("ITEM DESCRIPTION: " + itemData.itemDescription);
        Debug.Log("ITEM EFFECT: " + itemData.itemEffect.ToString());
    }
}
