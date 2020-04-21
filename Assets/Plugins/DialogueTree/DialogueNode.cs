using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DialogueTree
{
    public class DialogueNode
    {
        private string Text;
        private int NodeID;
        private List<DialogueOptions> Options;

        public DialogueNode() { }
        public DialogueNode(string text)
        {
            this.Text = text;
            this.Options = new List<DialogueOptions>();
        }

        // SETTERS
        public void setID(int ID)
        {
            this.NodeID = ID;
        }
        public void setText(string text)
        {
            this.Text = text;
        }
        public void setOptions(List<DialogueOptions> opts)
        {
            this.Options = opts;
        }
        // END OF SETTERS

        // GETTERS
        public string getText()
        {
            return this.Text;
        }
        public int getID()
        {
            return this.NodeID;
        }
        public List<DialogueOptions> getOptions()
        {
            return this.Options;
        }
        // END OF GETTERS
    }
}
