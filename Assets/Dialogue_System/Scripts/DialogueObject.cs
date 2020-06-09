using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueObject
{
    public const int MAX_PARENTS = 4; 

    private int dialogueNodeID;
    private int[] dialogueParentNodeID;
    private DialogueScript.DialogueType dialogueType;
    private string dialogueTitle;
    private string dialogueText;
    private int dialogueLeftNodeID; // The YES answer
    private int dialogueRightNodeID; // The NO answer. If both null, "OK" dialogue type.

    // GETTERS
    public int GetDialogueNodeID()
    {
        return this.dialogueNodeID;
    }
    public int[] GetDialogueParentNodeID()
    {
        return this.dialogueParentNodeID;
    }
    public DialogueScript.DialogueType GetDialogueType()
    {
        return this.dialogueType;
    }
    public string GetDialogueTitle()
    {
        return this.dialogueTitle;
    }
    public string GetDialogueText()
    {
        return this.dialogueText;
    }
    public int GetDialogueLeftNode()
    {
        return this.dialogueLeftNodeID;
    }
    public int GetDialogueRightNode()
    {
        return this.dialogueRightNodeID;
    }
    //GETTERS END

    //SETTERS
    public void SetDialogueLeftNode(int _newID)
    {
        this.dialogueLeftNodeID = _newID;
    }
    public void SetDialogueRightNode(int _newID)
    {
        this.dialogueRightNodeID = _newID;
    }
    //SETTERS END

    public static DialogueObject CreateFromJSON(string _jsonString)
    {
        return JsonUtility.FromJson<DialogueObject>(_jsonString);
    }
}
