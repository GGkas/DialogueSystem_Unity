using System;
using System.Collections.Generic;
using System.Text;

namespace DialogueTree
{
    public class DialogueOptions
    {
        private int DestNodeID;

        private string Text; // could also be list/dict of strings

        public DialogueOptions() { }

        public DialogueOptions(string text, int destID)
        {
            this.Text = text;
            this.DestNodeID = destID;
        }
    }
}
