using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

namespace GBQuestSystem{
    public class QuestNode : Node{
        public GBQuestData data;

        public QuestNode(GBQuestData nodeData){
            data = nodeData;
            
            title = "Test Title";

            var objectField = new ObjectField("Quest reference");
            objectField.objectType = typeof(GBQuestData);
            objectField.value = nodeData.nextQuest;

            // Actualizar el modelo cuando cambie
            objectField.RegisterValueChangedCallback(evt =>{
                nodeData = evt.newValue as GBQuestData;
                title = nodeData.questTittle;
                Debug.Log("[GBQuest Graph] Updated Linked Object" + nodeData.name);
            });

            extensionContainer.Add(objectField);

            // NODES
            AddInputNodes();
            AddOutputNodes();

            // Show Description
            var descriptionLabel = new UnityEngine.UIElements.Label("Test Description");
            mainContainer.Add(descriptionLabel);

            RefreshExpandedState();
            RefreshPorts();
        }

        private void AddInputNodes(){
            var inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(GBQuestData));
            inputPort.name = "Previous Quest"; 
            inputContainer.Add(inputPort);
        }

        private void AddOutputNodes(){
            var outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(GBQuestData));
            outputPort.name = "Next Quest";
            outputContainer.Add(outputPort);
        }
    }
}