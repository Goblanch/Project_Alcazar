using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;

public class UIController : MonoBehaviour
{
    public MouseContextMenuController contextMenu;
    public SubtitleController subtitles;
    private UIMediator _mediator;

    private const float SUBSTIME = 2f;

    #region CONTEXT MENU ACTIONS

    public static Action ContextMenuStartEvent;
    public static Action ContextMenuEvent;
    public static Action ContextMenuEndEvent;
    public static Action<ClickableData> ContextMenuDataEvent;
    
    #endregion
    public static Action<string, float> AddSubtittleEvent;

    public void Configure(UIMediator _mediator){
        this._mediator = _mediator;
    }

    private void OnEnable() {
        // TODO: change to UIMediator function
        // ContextMenuEvent += contextMenu.UpdateMenuPosition;
        // ContextMenuStartEvent += _mediator.ShowContextMenu;
        // ContextMenuDataEvent +=  _mediator.SetContextMenuData;
        // ContextMenuEndEvent += _mediator.HideMouseContextMenu;

        //AddSubtittleEvent += AddSubtitle;
    }

    private void OnDisable() {
        // TODO: change to UIMediator function
        // ContextMenuEvent -= contextMenu.UpdateMenuPosition;
        // ContextMenuStartEvent -= _mediator.ShowContextMenu;
        // ContextMenuEndEvent -= _mediator.HideMouseContextMenu;
        // ContextMenuDataEvent -=  _mediator.SetContextMenuData;

        //AddSubtittleEvent -= AddSubtitle;
    }

    // TODO: encapsular la lógica de los substítulo dentro de una clase de subtítulos y añadirlo
    // TODO: al mediator. Una vez hecho, borrar esta clase UIController
    public void AddSubtitle(string subtitle, float time = SUBSTIME){
        subtitles.gameObject.SetActive(true);
        subtitles.AddSubtitle(subtitle, time);
    }
}
