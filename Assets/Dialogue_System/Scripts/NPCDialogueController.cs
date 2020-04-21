using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using DialogueTree;

public class NPCDialogueController : MonoBehaviour
{
    // Used for testing
    [SerializeField]
    private Dialogue dia;

    [SerializeField]
    private GameObject DialogueWindow;

    private GameObject NodeText;
    private List<GameObject> options; // maybe list is not needed, will figure it out
    private GameObject exit;

    private int selected_option = -2; // it can be any initial value, tutorial was pepega

    [SerializeField]
    private string DialogueFilePath;
    [SerializeField]
    private GameObject DialogueWindowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        dia = Dialogue.LoadDialogue(DialogueFilePath);

        var canvas = GameObject.Find("Canvas");

        // Creates copy of the Prefab object
        DialogueWindow = Instantiate<GameObject>(DialogueWindowPrefab);
        DialogueWindow.transform.parent = canvas.transform;

        // Save transform information
        RectTransform dia_window_transform = (RectTransform)DialogueWindow.transform;
        dia_window_transform.localPosition = new Vector3(0, 0, 0); // Anchor is origin

        NodeText = GameObject.Find("Test_DNode_Text");
        // here go the inits of the options, don't know how I'll do this yet.
        exit = GameObject.Find("Button_End");

        /* This basically says: if you click the end button, run the function SetSelectedOption
         * with parameter -1 */
        exit.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(-1); });

        // Setting window to non-visible
        DialogueWindow.SetActive(false);

        /* Starts the dialogue event. Might be a function that depends on other conditions to have been
         * met in order to execute */
        RunDialogue();
    }

    // Starts coroutine
    public void RunDialogue()
    {
        StartCoroutine(run());
    }

    public void SetSelectedOption(int x)
    {
        selected_option = x;
    }

    public IEnumerator run()
    {
        DialogueWindow.SetActive(true);

        // start indexing from 0. Start node
        int node_ID = 0;

        // While we're not on an exit node
        while (node_ID != -1)
        {
            /* NOTE: I really don't like how the Nodes attribute is public, but if I edit it, I would 
             * have to re-build the library. I will try it tomorrow, and hope it doesn't destroy
             * any references. */
            DisplayNode(dia.Nodes[node_ID]);

            selected_option = -2;
            while (selected_option == -2)
            {
                yield return new WaitForSeconds(0.25f);
            }
            node_ID = selected_option;
        }
        DialogueWindow.SetActive(false);
    }

    private void DisplayNode(DialogueNode node)
    {
        NodeText.GetComponent<Text>().text = node.getText();

    }
}
