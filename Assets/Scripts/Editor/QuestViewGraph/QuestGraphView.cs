using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor;

namespace GBQuestSystem{
    public class QuestGraphView : GraphView{
        public QuestGraphView(){
            AddGridBackground();
            AddStyles();
            
            this.AddManipulator(new ContentZoomer());
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
        }

        private void AddGridBackground(){
            GridBackground gridBG = new GridBackground();

            gridBG.StretchToParentSize();

            Insert(0, gridBG);
        }

        private void AddStyles(){
            StyleSheet styeSheet = (StyleSheet) EditorGUIUtility.Load("GBQuestSystem/GBQuestGraphViewStyle.uss");

            styleSheets.Add(styeSheet);
        }

        // Manually handling compatible ports to create conexions
        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            // Devuelve los puertos compatibles para conexiones
            var compatiblePorts = new List<Port>();
            ports.ForEach(port =>
            {
                if (startPort != port &&
                    startPort.node != port.node && // No conectar a su propio nodo
                    startPort.direction != port.direction) // Direcciones opuestas
                {
                    compatiblePorts.Add(port);
                }
            });
            return compatiblePorts;
        }
    }

    
}