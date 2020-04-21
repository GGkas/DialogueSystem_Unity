using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using DialogueTree;
public class NPCDialogue : MonoBehaviour
{
    private Dialogue dia;

    // The window where dialogue is displayed in Unity
    private GameObject DialogueWindow;

    private GameObject nodetext;
    // Should be a list of gameobjects for generalization
    private List<GameObject> options;
    private GameObject exit;

    private int selected_option = -2; // I think it just needs to not be -1
    
    // Will need to create loaders for all serialzefield variables
    [SerializeField]
    private string DialogueFilePath;

    [SerializeField]
    private GameObject DialogueWinodwPrefab;

    void Start()
    {
        dia = Dialogue.LoadDialogue("Assets/" + DialogueFilePath);
        
        var canvas = GameObject.Find("Canvas");
        
        DialogueWindow = Instantiate<GameObject>(DialogueWinodwPrefab);
        DialogueWindow.transform.parent = canvas.transform; // Align the objects

        // Information about position, size etc of rectangle
        RectTransform dia_window_transform = (RectTransform)DialogueWindow.transform;
        dia_window_transform.localPosition = new Vector3(0, 0, 0); // Position of window is origin


    }



}
