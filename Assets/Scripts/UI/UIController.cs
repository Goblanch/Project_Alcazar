using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class UIController : MonoBehaviour
{
    public Text itemDataText;

    public static Action<ClickableData> sampleTextEvent; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable() {
        sampleTextEvent += HandleSampleTextEvent;
    }

    private void OnDisable() {
        sampleTextEvent -= HandleSampleTextEvent;
    }

    private void HandleSampleTextEvent(ClickableData itemData){
        itemDataText.text = itemData.itemName + " " + itemData.itemDescription;
    }
}
