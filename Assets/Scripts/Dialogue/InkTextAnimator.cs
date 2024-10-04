using Febucci.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class InkTextAnimator : MonoBehaviour
{
    public TextAsset inkJSONAsset;  // The Ink story JSON
    private Story story;  // Ink story object
    public TextMeshProUGUI dialogueText;  // TextMeshProUGUI for animated text
    private TextAnimator_TMP textAnimator;  // Text Animator component

    void Start()
    {
        story = new Story(inkJSONAsset.text);
        textAnimator = GetComponent<TextAnimator_TMP>();
        DisplayNextLine();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { DisplayNextLine(); }
        if (Input.GetKeyDown(KeyCode.Keypad0)) { ChooseOption(0); }
        if (Input.GetKeyDown(KeyCode.Keypad1)) { ChooseOption(1); }
        if (Input.GetKeyDown(KeyCode.Keypad2)) { ChooseOption(2); }
        if (Input.GetKeyDown(KeyCode.Keypad3)) { ChooseOption(3); }
        if (Input.GetKeyDown(KeyCode.Keypad4)) { ChooseOption(4); }
        if (Input.GetKeyDown(KeyCode.Keypad5)) { ChooseOption(5); }
    }

    void DisplayNextLine()
    {
        Debug.Log("DisplayNextLine");

        if (story.canContinue)
        {
            string text = story.Continue();  // Get next line from Ink
            Debug.Log("text=" + text);
            textAnimator.SetTextToSource(text);  // Animate the text using Text Animator
        }
    }

    // Call this method when player selects a choice
    public void ChooseOption(int choiceIndex)
    {
        try
        {
            story.ChooseChoiceIndex(choiceIndex);
        }
        catch (System.Exception e) {}

        DisplayNextLine();
    }
}
