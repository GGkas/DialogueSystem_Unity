using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public enum DialogueType
    {
        OKDialogue,
        YesNoDialogue
    };

    public CanvasGroup dialogueCanvasGroup;
    //this could be replaced by a json filename, which we will load and then parse
    //public string JSONFilePath;
    public GameObject okDialogueObject;
    public GameObject yesNoDialogueObject;

    // For navigating to previous dialogues?
    public List<string> text_history = new List<string>();
    public List<string> title_history = new List<string>();

    public TMP_Text dialogueText;
    public TMP_Text dialogueTitle;

    public delegate void dialogueAnswer();
    public dialogueAnswer okAnswer;
    public dialogueAnswer noAnswer;

    public bool dialogueResult = true;

    public static bool showingDialogue;

    public static DialogueScript instance; // singleton

    public static void PopUpDialogue(string _title, string _text, DialogueType _desiredDialogue=DialogueType.OKDialogue, dialogueAnswer _dialoguePositiveAnswer=null, dialogueAnswer _dialogueNegativeAnswer = null)
    {
        if (showingDialogue) return;

        instance.dialogueCanvasGroup.gameObject.SetActive(true);

        switch (_desiredDialogue) 
        {
            case DialogueType.OKDialogue:
                instance.okDialogueObject.SetActive(true);
                instance.yesNoDialogueObject.SetActive(false);
                break;
            case DialogueType.YesNoDialogue:
                instance.okDialogueObject.SetActive(false);
                instance.yesNoDialogueObject.SetActive(true);
                break;
        }

        instance.text_history.Add(_text);
        instance.title_history.Add(_title);

        instance.dialogueText.SetText(_text);
        instance.dialogueTitle.SetText(_title);
        instance.dialogueCanvasGroup.DOFade(1, 0.5f);

        instance.okAnswer = _dialoguePositiveAnswer;
        instance.noAnswer = _dialogueNegativeAnswer;

        showingDialogue = true;
    }

    public void DismissDialogue(bool _answer)
    {
        instance.dialogueCanvasGroup.DOFade(0, 0.5f).OnComplete(instance.hideCanvasGroup);

        if (_answer) 
        {
            okAnswer?.Invoke();
        }
        else
        {
            noAnswer?.Invoke();
        }        
    }

    public void hideCanvasGroup()
    {
        dialogueCanvasGroup.gameObject.SetActive(false);
        showingDialogue = false;
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
