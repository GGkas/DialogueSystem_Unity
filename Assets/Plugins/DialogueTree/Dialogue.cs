using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace DialogueTree
{
    public class Dialogue
    {
        public List<DialogueNode> Nodes;

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
            if (!Nodes.Contains(srcNode)) { addNode(srcNode); }

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
            // XML files loading.
            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamReader reader = new StreamReader(path);

            Dialogue dia = (Dialogue)serz.Deserialize(reader);
            return dia;
        }
    }
}
