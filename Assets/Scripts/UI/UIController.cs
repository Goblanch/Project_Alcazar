using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;

public class UIController : MonoBehaviour
{
    public MouseContextMenuController contextMenu;
    public SubtitleController subtitles;

    private const float SUBSTIME = 2f;

    #region CONTEXT MENU ACTIONS

    public static Action ContextMenuStartEvent;
    public static Action ContextMenuEvent;
    public static Action ContextMenuEndEvent;
    public static Action<ClickableData> ContextMenuDataEvent;
    
    #endregion
    public static Action<string, float> AddSubtittleEvent;
    private void OnEnable() {
        ContextMenuEvent += contextMenu.UpdateMenuPosition;
        ContextMenuStartEvent += contextMenu.ShowMouseContextMenu;
        ContextMenuDataEvent +=  contextMenu.SetContextMenuData;
        ContextMenuEndEvent += contextMenu.HideMouseContextMenu;

        AddSubtittleEvent += AddSubtitle;
    }

    private void OnDisable() {
        ContextMenuEvent -= contextMenu.UpdateMenuPosition;
        ContextMenuStartEvent -= contextMenu.ShowMouseContextMenu;
        ContextMenuEndEvent -= contextMenu.HideMouseContextMenu;

        AddSubtittleEvent -= AddSubtitle;
    }

    public void AddSubtitle(string subtitle, float time = SUBSTIME){
        subtitles.gameObject.SetActive(true);
        subtitles.AddSubtitle(subtitle, time);
    }
}
