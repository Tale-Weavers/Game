using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;

    public Queue<string> sentences;

    public Button continueButton;
    [TextArea(3, 10)]
    public string[] startSentences;

    private void Start()
    {
        
        dialogueBox.SetActive(false);
        sentences = new Queue<string>();
        StartDialogue(startSentences);
        continueButton.onClick.AddListener(DisplayNextSentence);
    }

    public void StartDialogue(string[] dialogueSentences)
    {
        dialogueBox.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogueSentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {

            EndDialogue();
            return;
        }

        
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.instance.onMenu = false;
    }

}
