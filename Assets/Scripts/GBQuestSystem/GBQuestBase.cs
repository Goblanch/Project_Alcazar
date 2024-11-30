using System.Collections.Generic;
using UnityEngine;

namespace GBQuestSystem{

    [System.Serializable]
    public enum DialogSenders{
        MainCharacter,
        NPC
    }

    [System.Serializable]
    public class DialogStructure{
        public string phrase;
        public DialogSenders sender;
    }

    public abstract class GBQuestBase : ScriptableObject
    {
        [SerializeField]protected List<DialogStructure> initialDialog;
        protected List<DialogStructure> endDialog;
        protected GBQuestBase nextQuest;

        public virtual void StartQuest(){StartDialogSeuqence(initialDialog);}
        protected virtual void EndQuest(){}
        protected virtual void StartDialogSeuqence(List<DialogStructure> dialog){}
        protected virtual void OnDialogStart(){}
        protected virtual void OnDialogEnd(){}
    }
}


