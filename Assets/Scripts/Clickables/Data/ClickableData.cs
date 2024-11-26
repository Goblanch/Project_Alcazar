using System.Collections.Generic;
using UnityEngine;

public enum ItemEffect{
    Good, Mid, Bad
}

[CreateAssetMenu(fileName = "ClickableData", menuName = "Scriptable Objects/ClickableData")]
public class ClickableData : ScriptableObject
{
    [Header("General Data")]
    public string itemName;
    public string itemDescription;
    public ItemEffect itemEffect;
    [Header("Combinations")]
    public List<ClickableData> combinesWith;
}
