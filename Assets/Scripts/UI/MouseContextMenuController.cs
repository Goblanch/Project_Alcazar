using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseContextMenuController : MonoBehaviour
{
    public Canvas parentCanvas;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    private UIMediator _mediator;

    public void Configure(UIMediator _mediator){
        this._mediator = _mediator;
    }

    private void Start() {
        HideMouseContextMenu();
    }

    public void UpdateMenuPosition(){
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
        parentCanvas.transform as RectTransform,
        Input.mousePosition, parentCanvas.worldCamera,
        out movePos);

        transform.position = parentCanvas.transform.TransformPoint(movePos);
    }

    public void ShowMouseContextMenu(){
        gameObject.SetActive(true);
    }

    public void HideMouseContextMenu(){
        gameObject.SetActive(false);
    }

    public void SetContextMenuData(ClickableData data){
        itemName.text = data.itemName;
        itemDescription.text = data.itemDescription;
    }   
}
