using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueCells
{
    [Serializable]
    public struct DialogueObject
    {
        public int dialogueID;
        public int[] dialogueParentNodeID;
        public string dialogueType;
        public string dialogueTitle;
        public string dialogueText;
        public int dialogueLeftNodeID; // The YES answer
        public int dialogueRightNodeID; // The NO answer. If both null, "OK" dialogue type.
    };

    [SerializeField]
    private DialogueObject[] dialogueCells = new DialogueObject[10];

    public string GetDialogueType(int index)
    {
        return this.dialogueCells[index].dialogueType;
    }
    public string GetDialogueTitle(int index)
    {
        return this.dialogueCells[index].dialogueTitle;
    }
    public string GetDialogueText(int index)
    {
        return this.dialogueCells[index].dialogueText;
    }
    public int GetDialogueLeftNode(int index)
    {
        return this.dialogueCells[index].dialogueLeftNodeID;
    }
    public int GetDialogueRightNode(int index)
    {
        return this.dialogueCells[index].dialogueRightNodeID;
    }
}
