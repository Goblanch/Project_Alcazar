using System.Collections.Generic;
using GBQuestSystem;
using UnityEngine;

[CreateAssetMenu(fileName = "GBQuestSimple", menuName = "GBQuests/GBQuestSimple")]
public class GBQuestSimple : GBQuestBase
{
    public override void StartQuest(){
        base.StartQuest();
    }
    protected override void EndQuest(){}
    protected override void StartDialogSeuqence(List<DialogStructure> dialog){
        DialogueManager.EventStartDialogue?.Invoke(dialog);
    }
    protected override void OnDialogStart(){}
    protected override void OnDialogEnd(){}
}
