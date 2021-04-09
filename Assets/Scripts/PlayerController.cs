using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script responsável pelos controles do player
public class PlayerController : MonoBehaviour
{
    // Variáveis
    private Rigidbody2D _rigidbody2D;
    private DialogueManager _dialogueManager;
    private GameManager _gameManager;

    // Header para adicionar um cabeçalho no Inspector para as variáveis para fácil localização
    // SerializeField para permitir aparecer no Inspector mesmo sendo private
    [Header("Variáveis de movimento")]
    [SerializeField]
    private float _speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        // Pega o rigidbody2D
        _rigidbody2D = GetComponent<Rigidbody2D>();

        // Dialogue manager
        _dialogueManager = GetComponent<DialogueManager>();

        // Game manager
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // If dialogue mode
        if (_gameManager.isDialogueMode)
        {
            _rigidbody2D.velocity = Vector2.zero;

            // Get input for next sentence
            if (Input.GetKeyDown(KeyCode.E))
            {
                _dialogueManager.NextSentence();
            }

            return;
        }

        // Movement
        Movement();
    }

    /// <summary>
    /// Player movement controllers
    /// </summary>
    void Movement()
    {
        // Pega os inputs
        // Vertical - Setas para cima e para baixo, ou, W e S
        // Horizontal - Setas para esquerda e para direita, ou, A e D
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Um novo vector2 com os inputs (que vão de -1 a 1, podendo ser 0) * Delta time (tempo entre frames) * _speed - A velocidade de movimento
        _rigidbody2D.velocity = new Vector2(horizontalInput, verticalInput) * Time.deltaTime * _speed;
        // transform.Translate(new Vector2(horizontalInput, verticalInput) * Time.deltaTime * _speed);
    }

    /// <summary>
    /// Interact with a object
    /// OBS: Used outside of the player script
    /// <param name="interactType">Interaction type enum</param>
    /// <param name="dialogue">The dialogue that will be displayed</param>
    /// </summary>
    public void Interact(InteractableObjectManager.InteractType interactType, Dialogue dialogue)
    {
        switch (interactType)
        {
            case InteractableObjectManager.InteractType.Pick:
                Debug.Log("Object picked up");
                dialogue.name = "";
                _dialogueManager.StartDialogue(dialogue);
                break;

            case InteractableObjectManager.InteractType.Read:
                Debug.Log("Reading object");
                break;

            case InteractableObjectManager.InteractType.Talk:
                Debug.Log("Talking with NPC");
                _dialogueManager.StartDialogue(dialogue);
                break;
        }
    }
}
