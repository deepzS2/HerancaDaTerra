using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Dialogue customization")]
    [SerializeField]
    private float _sentenceWithNameHeight;

    [SerializeField]
    private float _sentenceWithoutNameHeight;

    [SerializeField]
    private float _sentenceWithoutNamePos;

    [SerializeField]
    private float _sentenceWithNamePos;

    [Header("Dialogue text")]
    [SerializeField]
    private Text _nameDialogue;

    [SerializeField]
    private Text _sentenceDialogue;

    [SerializeField]
    private RectTransform _sentenceTransform;

    [SerializeField]
    private GameObject _dialoguePanel;

    // Um texto
    private Text _testText;

    // Variável de teste
    private int _counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Pega o componente de texto pelo nome do game object
        _testText = GameObject.Find("TestText").GetComponent<Text>();

        // Começa uma rotina
        StartCoroutine(Counter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Uma rotina de teste
    /// </summary>
    IEnumerator Counter()
    {
        // Sempre executando
        while (true)
        {
            // Coloca o novo texto
            _testText.text = "This is a UI Manager script working\n" + _counter + " seconds has passed";

            // Aumenta o counter
            _counter++;

            // Espera 1 segundo 
            yield return new WaitForSeconds(1f);
        }
    }

    /// <summary>
    /// Display sentence
    /// </summary>
    /// <param name="sentence">String sentence</param>
    public void DisplaySentence(string sentence)
    {
        // If the dialogue panel is not active, active it
        if (!_dialoguePanel.activeInHierarchy) _dialoguePanel.SetActive(true);

        // Set new height and new position if it is only a sentence without name
        _sentenceTransform.sizeDelta = new Vector2(_sentenceTransform.rect.width, _sentenceWithoutNameHeight);
        _sentenceTransform.anchoredPosition = new Vector2(_sentenceTransform.anchoredPosition.x, _sentenceWithoutNamePos); //new Vector3(_sentenceTransform.position.x, 2.056f);

        // No name dialogue
        _nameDialogue.text = "";

        // Set sentence text and font style
        _sentenceDialogue.text = sentence;
        _sentenceDialogue.fontStyle = FontStyle.Italic;
    }

    /// <summary>
    /// Display sentence
    /// </summary>
    /// <param name="name">Name of the NPC/Object</param>
    /// <param name="sentence">String sentence</param>
    public void DisplaySentence(string name, string sentence)
    {
        // If the dialogue panel is not active, active it
        if (!_dialoguePanel.activeInHierarchy) _dialoguePanel.SetActive(true);

        // Set new height and new position if it is only a sentence with name
        _sentenceTransform.sizeDelta = new Vector2(_sentenceTransform.rect.width, _sentenceWithNameHeight);
        _sentenceTransform.anchoredPosition = new Vector2(_sentenceTransform.anchoredPosition.x, _sentenceWithNamePos);

        // Set the name and sentence text
        _nameDialogue.text = name;
        _sentenceDialogue.text = sentence;
    }

    /// <summary>
    /// End dialogue text display
    /// </summary>
    public void EndDialogue()
    {
        // Deactive panel
        _dialoguePanel.SetActive(false);

        // Reset texts
        _nameDialogue.text = "";
        _sentenceDialogue.text = "";
    }
}
