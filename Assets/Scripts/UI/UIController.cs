using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;

public class UIController : MonoBehaviour
{
    public MouseContextMenuController contextMenu;

    #region CONTEXT MENU ACTIONS

    public static Action ContextMenuStartEvent;
    public static Action ContextMenuEvent;
    public static Action ContextMenuEndEvent;
    public static Action<ClickableData> ContextMenuDataEvent;
    
    #endregion
    
    private void OnEnable() {
        ContextMenuEvent += contextMenu.UpdateMenuPosition;
        ContextMenuStartEvent += contextMenu.ShowMouseContextMenu;
        ContextMenuDataEvent +=  contextMenu.SetContextMenuData;
        ContextMenuEndEvent += contextMenu.HideMouseContextMenu;

    }

    private void OnDisable() {
        ContextMenuEvent -= contextMenu.UpdateMenuPosition;
        ContextMenuStartEvent -= contextMenu.ShowMouseContextMenu;
        ContextMenuEndEvent -= contextMenu.HideMouseContextMenu;
    }

}
