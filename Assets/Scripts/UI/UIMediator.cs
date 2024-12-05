using UnityEngine;

public class UIMediator : MonoBehaviour
{
    [SerializeField] private UIController _ui;
    [SerializeField] private MouseContextMenuController _mContextMenu;

    private void Awake() {
        _ui.Configure(this);
        _mContextMenu.Configure(this);
    }

    public void ShowContextMenu(){
        _mContextMenu.gameObject.SetActive(true);
    }

    public void HideMouseContextMenu(){
        _mContextMenu.gameObject.SetActive(false);
    }


    public void SetContextMenuData(ClickableData data){
        _mContextMenu.itemName.text = data.itemName;
        _mContextMenu.itemDescription.text = data.itemDescription;
    }   
}
