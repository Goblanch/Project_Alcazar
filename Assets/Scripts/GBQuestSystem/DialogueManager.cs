using GBQuestSystem;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class DialogueManager : MonoBehaviour
{
    public static Action<List<DialogStructure>> EventStartDialogue;

    private void OnEnable() {
        EventStartDialogue += StartDialogueSequence;
    }

    private void OnDisable() {
        EventStartDialogue -= StartDialogueSequence;
    }

    public void StartDialogueSequence(List<DialogStructure> dialogue){
        StartCoroutine(PlayDialogueSequence(dialogue));
    }

    private IEnumerator PlayDialogueSequence(List<DialogStructure> dialogue){
        foreach(DialogStructure phrase in dialogue){
            UIController.AddSubtittleEvent?.Invoke(phrase.phrase, 3f);
            yield return new WaitForSeconds(3f);
        }

        yield return null;
    }
}
