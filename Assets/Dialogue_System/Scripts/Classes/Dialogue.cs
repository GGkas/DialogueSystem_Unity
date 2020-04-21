using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueTree
{
    public class Dialogue : MonoBehaviour
    {   
        [SerializeField]
        private List<DialogueNode> Nodes;

        public Dialogue()
        {
            Nodes = new List<DialogueNode>();
        }

        public void addNode(DialogueNode node)
        {
            // If node is null, then exitNode, skip it
            if (node == null) return;

            // Add node to dialogue list
            this.Nodes.Add(node);
            // Give node and ID
            node.setID(Nodes.IndexOf(node));
        }
        
        public void addOption(string text, DialogueNode srcNode, DialogueNode destNode)
        {
            // add dest node to dialogue if not there
            if (!Nodes.Contains(destNode)) { addNode(destNode); }

            // add source node to dialogue if not there
            if (!Nodes.Contains(srcNode)) { addNode(srcNode);  }

            DialogueOptions opt;
            
            // If dest is exit node, set ID to -1
            if (destNode == null)
            {
                opt = new DialogueOptions(text, -1);
            }
            else
            {
                opt = new DialogueOptions(text, destNode.getID());
            }
            // Add options to parent node
            srcNode.getOptions().Add(opt);
        }
        
        public static Dialogue LoadDialogue(string path)
        {
            //JSON OR XML, will have to choose

            return dia;
        }
    }
}

