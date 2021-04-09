using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectManager : MonoBehaviour
{
    // Enums
    public enum InteractType
    {
        Pick = 0,
        Read,
        Talk
    }
    [Header("Interaction type")]

    // Tipo de interação
    // 0 - Pegar, 1 - Ler, 2 - Falar
    [SerializeField]
    private InteractType _interactionType = 0;

    [Header("Interaction message")]
    [SerializeField]
    private Dialogue _dialogue;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If the collision object is the player and he press E
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            // Get player controller
            PlayerController playerController = collision.GetComponent<PlayerController>();

            // If it don't exists do nothing
            if (!playerController)
            {
                return;
            }

            // Interact
            playerController.Interact(_interactionType, _dialogue);
        }
    }
}
