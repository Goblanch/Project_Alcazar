using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace GBQuestSystem{
    public class QuestNode : Node{
        public GBQuestData data;

        public QuestNode(GBQuestData nodeData){
            data = nodeData;
            // TODO: Add title from scriptable object

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
            var inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(float));
            inputPort.name = "Input";
            inputContainer.Add(inputPort);
        }

        private void AddOutputNodes(){
            var outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(float));
            outputPort.name = "Output";
            outputContainer.Add(outputPort);
        }
    }
}