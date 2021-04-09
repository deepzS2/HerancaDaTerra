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

    // Start is called before the first frame update
    void Start()
    {

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
