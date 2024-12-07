using System.Collections.Generic;
using UnityEngine;

public class UIMediator : MonoBehaviour
{
    [SerializeField] private UIController _ui;
    [SerializeField] private MouseContextMenuController _mContextMenu;
    [SerializeField] private SubtitleController _subtittles;

    private List<IClickable> clickables;

    public void SetupObservers(IClickable clickable){

        clickable.OnHoverStartEvent += ShowContextMenu;
        clickable.OnHoverEvent      += _mContextMenu.UpdateMenuPosition;
        clickable.OnHoverEndEvent   += HideMouseContextMenu;

        clickables.Add(clickable);
    }
    
    private void OnDisable() {
        foreach(ClickableBase clickable in clickables){
            clickable.OnHoverStartEvent -= ShowContextMenu;
            clickable.OnHoverEvent      -= _mContextMenu.UpdateMenuPosition;
            clickable.OnHoverEndEvent   -= HideMouseContextMenu;
        }  
    }

    private void Awake() {
        _ui.Configure(this);
        _mContextMenu.Configure(this);
        _subtittles.Configure(this);

        clickables = new List<IClickable>();
    }

    public void ShowContextMenu(ClickableData data){
        _mContextMenu.gameObject.SetActive(true);
        SetContextMenuData(data);
    }

    public void HideMouseContextMenu(){
        Debug.Log("Escondo el menú");
        _mContextMenu.gameObject.SetActive(false);
    }


    private void SetContextMenuData(ClickableData data){
        _mContextMenu.itemName.text = data.itemName;
        _mContextMenu.itemDescription.text = data.itemDescription;
    }
}
