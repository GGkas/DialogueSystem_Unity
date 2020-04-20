using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueTree
{
    public class DialogueOptions : MonoBehaviour
    {
        [SerializeField]
        private int DestNodeID;

        [SerializeField]
        private string Text; // could also be list/dict of strings
        
        public DialogueOptions() {}

        public DialogueOptions(string text, int destID) 
        {
            this.Text = text;
            this.DestNodeID = destID;
        }
    }
}