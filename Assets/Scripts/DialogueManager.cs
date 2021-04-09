using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentences;
    private UIManager _uiManager;
    private string _name;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Sentences 
        _sentences = new Queue<string>();

        // UI Manager
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
        // Game manager
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // Clear the last sentences
        _sentences.Clear();

        // Dialogue mode true
        _gameManager.isDialogueMode = true;

        // Each sentence enqueue
        foreach(string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        // Name of the NPC if necessary
        _name = dialogue.name;
    }

    public void NextSentence()
    {
        // If no more sentences
        if (_sentences.Count == 0)
        {
            // End dialogue
            _uiManager.EndDialogue();

            // Dialogue mode false
            _gameManager.isDialogueMode = false;

            return;
        }

        // Sentence dequeue
        string sentence = _sentences.Dequeue();

        // If there's a name display sentence with name
        // Else display only the sentence
        if (_name == "" || _name == null)
        {
            _uiManager.DisplaySentence(sentence);
        }
        else
        {
            _uiManager.DisplaySentence(_name, sentence);
        }
    }
}
