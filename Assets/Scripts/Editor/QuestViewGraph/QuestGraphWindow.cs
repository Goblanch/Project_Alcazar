using UnityEditor;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;


namespace GBQuestSystem{
    public class QuestGraphWindow : EditorWindow
    {   
        [MenuItem("Tools/Quest Graph")]
        public static void Open(){
            var window = GetWindow<QuestGraphWindow>();
            window.titleContent = new UnityEngine.GUIContent("Quest Graph");
        }

        private void OnEnable() {
            var questGraphView = new QuestGraphView{
                name = "Graph View"
            };

            questGraphView.StretchToParentSize();
            rootVisualElement.Add(questGraphView);

            // Add node button
            var toolbar = new Toolbar();
            var addButton = new Button(() => CreateNode(questGraphView)) {text = "Add Node"};
            toolbar.Add(addButton);
            rootVisualElement.Add(toolbar);
        }

        private void CreateNode(QuestGraphView graphView){
            var nodeData = ScriptableObject.CreateInstance<GBQuestData>();
            // TODO: Set GBQuestData default values
            var node = new QuestNode(nodeData);
            node.SetPosition(new Rect(Vector2.zero, new Vector2(200, 150)));
            graphView.AddElement(node);
        }
    }
}

