using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !DialogueScript.showingDialogue)
        {
            DialogueScript.PopUpDialogue("START", "Welcome to the introductory dialogue!", TurnRed);
        }
    }

    // This could be a callback to some special effect on the text or to get to the next
    // conversation block (after implementing JSON)
    void TurnRed()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
