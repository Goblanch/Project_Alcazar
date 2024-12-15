using UnityEngine;
using System.Collections.Generic;

namespace GBQuestSystem{
    [CreateAssetMenu(fileName = "GBQuestData", menuName = "GBQuest/GBQuestData")]
    public class GBQuestData : ScriptableObject
    {
        public string questTittle;
        public List<DialogStructure> initialDialog = new List<DialogStructure>();
        public List<DialogStructure> endDialog = new List<DialogStructure>();
        public GBQuestData nextQuest;
    }   

}