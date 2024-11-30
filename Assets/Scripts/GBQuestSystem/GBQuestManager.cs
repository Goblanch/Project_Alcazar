using System.Collections.Generic;
using UnityEngine;

namespace GBQuestSystem{
    public class GBQuestManager : MonoBehaviour
    {
        public List<GBQuestBase> quests;
        private int _currentQuestIndex;

        private void Start() {
            NextQuest(null);
        }

        public void NextQuest(GBQuestBase nextQuest){
            quests[0].StartQuest();
        }
    }
}
