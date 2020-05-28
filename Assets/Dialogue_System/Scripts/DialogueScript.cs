using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public CanvasGroup dialogueCanvasGroup;
    //this could be replaced by a json filename, which we will load and then parse
    //public string JSONFilePath;
    public TMP_Text dialogueText;
    public TMP_Text dialogueTitle;

    public static bool showingDialogue;

    public static DialogueScript instance; // singleton

    public static void PopUpDialogue(string _title, string _text)
    {
        if (showingDialogue) return;

        instance.dialogueText.SetText(_text);
        instance.dialogueTitle.SetText(_title);
        instance.dialogueCanvasGroup.DOFade(1, 0.5f);
        showingDialogue = true;
    }

    public void DismissDialogue()
    {
        instance.dialogueCanvasGroup.DOFade(0, 0.5f).OnComplete(instance.hideCanvasGroup);
        showingDialogue = false;
    }

    public void hideCanvasGroup()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
