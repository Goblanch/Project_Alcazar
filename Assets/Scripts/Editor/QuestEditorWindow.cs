using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace GBQuestSystem{
    public class QuestEditorWindow : EditorWindow
    {
        private enum QuestEditorModes{
            None, Create, Edit
        }

        private QuestEditorModes currentMode = QuestEditorModes.None;

    #region CREATE MODE VARIABLES
        private List<DialogStructure> initialDialog = new List<DialogStructure>();
        private List<DialogStructure> endDialog = new List<DialogStructure>();
        private GBQuestBase nextQuest;
    #endregion
    
    #region EDIT MODE VARIABLES
        private GBQuestData selQuest;
        private List<DialogStructure> selInitialDialog;
        private List<DialogStructure> selEndDialog;
        private GBQuestBase selNextQuest;
    #endregion

        [MenuItem("Tools/Quest Editor")]
        public static void ShowWindow(){
            GetWindow<QuestEditorWindow>("Quest Editor");
        }

        private void OnGUI() {
            GUILayout.Label("Select Mode: ", EditorStyles.boldLabel);

            if(currentMode == QuestEditorModes.None){
                
                if(GUILayout.Button("Create new Quest")){
                    currentMode = QuestEditorModes.Create;
                }

                if(GUILayout.Button("Edit existent")){
                    currentMode = QuestEditorModes.Edit;
                }

            }else if(currentMode == QuestEditorModes.Create){

                DrawCreateWindow();

            }else if(currentMode == QuestEditorModes.Edit){

                DrawEditWindow();

            }

            if(currentMode != QuestEditorModes.None && GUILayout.Button("Back")){

                ResetMode();

            }
        }

        private void DrawCreateWindow(){
            GUILayout.Label("Create new Dialog", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            GUILayout.Label("Initial Dialog", EditorStyles.boldLabel);

            // INITIAL DIALOG
            for(int i = 0; i < initialDialog.Count; i++){
                GUILayout.BeginHorizontal();

                initialDialog[i].phrase = EditorGUILayout.TextField($"Phrase {i + 1}", initialDialog[i].phrase);
                initialDialog[i].sender = (DialogSenders)EditorGUILayout.EnumPopup("Emissor", initialDialog[i].sender);

                // Deleteproperty button
                if(GUILayout.Button("X", GUILayout.Width(20))){
                    initialDialog.RemoveAt(i);
                }

                GUILayout.EndHorizontal();
            }

            // Add property button
            if(GUILayout.Button("Add phrase")){
                initialDialog.Add(new DialogStructure());
            }

            EditorGUILayout.Space();

            // END DIALOG
            GUILayout.Label("End Dialog", EditorStyles.boldLabel);

            for(int i = 0; i < endDialog.Count; i++){
                GUILayout.BeginHorizontal();

                endDialog[i].phrase = EditorGUILayout.TextField($"Phrase {i + 1}", endDialog[i].phrase);
                endDialog[i].sender = (DialogSenders)EditorGUILayout.EnumPopup("Emissor", endDialog[i].sender);

                // Deleteproperty button
                if(GUILayout.Button("X", GUILayout.Width(20))){
                    endDialog.RemoveAt(i);
                }

                GUILayout.EndHorizontal();
            }

            // Add property button
            if(GUILayout.Button("Add phrase")){
                endDialog.Add(new DialogStructure());
            }

            EditorGUILayout.Space();

            // NEXT QUEST FIELD
            nextQuest = (GBQuestBase)EditorGUILayout.ObjectField("Referencia de Personaje", nextQuest, typeof(GBQuestBase), false);

            if(GUILayout.Button("Generate Quest File")){
                // TODO: Call SO generator method
                CreateSctiptableObject();
            }
        }

        private void DrawEditWindow(){
            GUILayout.Label("Edit Mode", EditorStyles.boldLabel);

            // ScriptableObject selection
            selQuest = (GBQuestData)EditorGUILayout.ObjectField("Select Quest Asset", selQuest, typeof(GBQuestData), false);

            if(selQuest != null){

                SetSelectedQuestData();

                // INITIAL DIALOG
                for(int i = 0; i < initialDialog.Count; i++){
                    GUILayout.BeginHorizontal();

                    initialDialog[i].phrase = EditorGUILayout.TextField($"Phrase {i + 1}", initialDialog[i].phrase);
                    initialDialog[i].sender = (DialogSenders)EditorGUILayout.EnumPopup("Emissor", initialDialog[i].sender);

                    // Deleteproperty button
                    if(GUILayout.Button("X", GUILayout.Width(20))){
                        initialDialog.RemoveAt(i);
                    }

                    GUILayout.EndHorizontal();
                }

                // Add property button
                if(GUILayout.Button("Add phrase")){
                    initialDialog.Add(new DialogStructure());
                }

                EditorGUILayout.Space();

                // END DIALOG
                GUILayout.Label("End Dialog", EditorStyles.boldLabel);

                for(int i = 0; i < endDialog.Count; i++){
                    GUILayout.BeginHorizontal();

                    endDialog[i].phrase = EditorGUILayout.TextField($"Phrase {i + 1}", endDialog[i].phrase);
                    endDialog[i].sender = (DialogSenders)EditorGUILayout.EnumPopup("Emissor", endDialog[i].sender);

                    // Deleteproperty button
                    if(GUILayout.Button("X", GUILayout.Width(20))){
                        endDialog.RemoveAt(i);
                    }

                    GUILayout.EndHorizontal();
                }

                // Add property button
                if(GUILayout.Button("Add phrase")){
                    endDialog.Add(new DialogStructure());
                }

                EditorGUILayout.Space();

                // NEXT QUEST FIELD
                nextQuest = (GBQuestBase)EditorGUILayout.ObjectField("Referencia de Personaje", nextQuest, typeof(GBQuestBase), false);

                if(GUILayout.Button("Save Changes")){
                    SaveQuestChanges();
                }
            }

        }

        private void SetSelectedQuestData(){
            initialDialog = selQuest.initialDialog;
            endDialog = selQuest.endDialog;
            nextQuest = selQuest.nextQuest;
        }

        private void SaveQuestChanges(){
            if(selQuest == null){
                Debug.LogWarning("No Quest Asset Selected");
                return;
            }

            // Save changes into Scriptable Object
            // selQuest.initialDialog = selInitialDialog;
            // selQuest.endDialog = selEndDialog;
            // selQuest.nextQuest = selNextQuest;

            // Mark object as modified
            EditorUtility.SetDirty(selQuest);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log($"Changes saved at {selQuest.name}");
        }

        private void ResetMode(){
            currentMode = QuestEditorModes.None;

            initialDialog = new List<DialogStructure>();
            endDialog = new List<DialogStructure>();
            nextQuest = null;

            selInitialDialog = new List<DialogStructure>();
            selEndDialog = new List<DialogStructure>();
            selNextQuest = null;
            selQuest = null;
        }

        private void CreateSctiptableObject(){
            if(initialDialog.Count == 0){
                Debug.LogWarning("Can't create file with empty list");
                return;
            }

            // Creating new SO instance
            GBQuestData newQuestData = CreateInstance<GBQuestData>();
            SaveDataToSO(newQuestData);

            // Saving SO
            string path = EditorUtility.SaveFilePanelInProject("Save Quest Data", "NewQuestData", "asset", "Choose save folder");
            if(!string.IsNullOrEmpty(path)){
                AssetDatabase.CreateAsset(newQuestData, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                EditorUtility.FocusProjectWindow();
                Selection.activeObject = newQuestData;

                Debug.Log($"Succesfuly created new quest in: {path}");
            }else{
                Debug.LogWarning("New quest file creating cancelled");
            }
        }

        private void SaveDataToSO(GBQuestData questInstance){
            questInstance.initialDialog = initialDialog;
            questInstance.endDialog = endDialog;
            questInstance.nextQuest = nextQuest;
        }
    }
}


