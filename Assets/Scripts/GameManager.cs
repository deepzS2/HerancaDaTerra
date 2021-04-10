using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script responsável para organização do jogo
// Saves, se ele está em tal fase, se foi game over, spawnar player, etc.
public class GameManager : MonoBehaviour
{
    // Variables
    private bool _isDialogueMode = false;

    [Header("Game objects")]
    [SerializeField]
    private GameObject _player;

    private bool _isOnMenu = false;

    private UIManager _uiManager;
    private MenuManager _menuManager;

    // Start is called before the first frame update
    void Start()
    {
        // Caso player nn exista estamos no menu!
        if (_player == null)
        {
            _isOnMenu = true;
        }

        if (_isOnMenu) { 
            _menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();
        }
        else _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool isDialogueMode {
        get { return _isDialogueMode; }
        set { _isDialogueMode = value; }
    }
}
