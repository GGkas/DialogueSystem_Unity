using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class Game : MonoBehaviour
{
    public DialogueCells dialogueCollection;
    public string JSONFilePath;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        JSONFilePath = Application.dataPath + "/Dialogue_System/Misc/dialogue_tree.json";
        using (StreamReader stream = new StreamReader(JSONFilePath))
        {
            string json = stream.ReadToEnd();
            dialogueCollection = JsonUtility.FromJson<DialogueCells>(json);
        }
        Debug.Log(JsonUtility.ToJson(dialogueCollection));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !DialogueScript.showingDialogue)
        {
            if (dialogueCollection.GetDialogueType(index) == "YES_NO")
            {
                DialogueScript.PopUpDialogue(dialogueCollection.GetDialogueTitle(index),
                    dialogueCollection.GetDialogueText(index),
                    DialogueScript.DialogueType.YesNoDialogue ,PressYes, PressNo);
            }
            else if (dialogueCollection.GetDialogueType(index) == "OK")
            {
                DialogueScript.PopUpDialogue(dialogueCollection.GetDialogueTitle(index),
                    dialogueCollection.GetDialogueText(index),
                    DialogueScript.DialogueType.OKDialogue, null, null);
            }
        }
    }

    // This could be a callback to some special effect on the text or to get to the next
    // conversation block (after implementing JSON)
    void PressYes()
    {
        index = dialogueCollection.GetDialogueLeftNode(index) - 1;
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
    void PressNo()
    {
        index = dialogueCollection.GetDialogueRightNode(index) - 1;
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
