/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Handles player interactions with Raycasting, as well as ensuring key inputs work properly (e.g. E, Esc)
 */

using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles player input for looking at and interacting with objects through a centre-screen raycast.
/// </summary>
public class PlayerInteraction : MonoBehaviour
{
    /// <summary>
    /// Maximum distance the player can be from an interactable object before the raycast stops detecting it.
    /// </summary>
    [SerializeField] private float interactionRange = 2f; // how close player needs to be for raycast to fire

    /// <summary>
    /// Layers that the interaction raycast is allowed to hit.
    /// </summary>
    [SerializeField] private LayerMask raycastLayer; // raycast can ONLY hit this layer of gameobj

    /// <summary>
    /// Current interactable object detected by the player's raycast.
    /// </summary>
    private IInteractible currentInteractible; // saves objs that can be interacted with

    /// <summary>
    /// Checks every frame whether the player is looking at an interactable object.
    /// </summary>
    private void Update()
    {
        PerformRaycast();
    }

    /// <summary>
    /// Casts a ray from the middle of the camera view and updates interaction UI based on what is hit.
    /// </summary>
    private void PerformRaycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, raycastLayer, QueryTriggerInteraction.Collide)) // if raycast hits obj in interactLayer
        {
            if (hit.collider.gameObject.TryGetComponent<IInteractible>(out currentInteractible)) // if obj is Interactible
            {
                UIManager.instance.SetInteractText(true, currentInteractible.GetInteractText()); // changes Interact message according to gameObject
            }
            else
            {
                currentInteractible = null;
                UIManager.instance.SetInteractText(false);
                UIManager.instance.SetPromptText(false);
            }
        }
        else
        {
            currentInteractible = null;
            UIManager.instance.SetInteractText(false);
            UIManager.instance.SetPromptText(false);
        }
    }

    /// <summary>
    /// Closes an open door when the player leaves its trigger area.
    /// </summary>
    /// <param name="other">Collider that the player stopped overlapping.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DoorScript>(out DoorScript doorScript))
        {
            doorScript.CloseDoor();
        }
    }

    /// <summary>
    /// Input System callback for pressing the interact button.
    /// </summary>
    /// <param name="value">Input value passed by Unity's Input System.</param>
    private void OnInteract(InputValue value)
    {
        Debug.Log("PLAYER: E pressed (interact)");

        if (currentInteractible != null)
        {
            currentInteractible.Interact();
            Debug.Log($"PLAYER: SUCCESS - Interacted with Interactible: {currentInteractible}");
        }
    }

    /// <summary>
    /// Input System callback for opening or closing the pause menu.
    /// </summary>
    /// <param name="value">Input value passed by Unity's Input System.</param>
    private void OnMenu(InputValue value)
    {
        GameManager.instance.TogglePause();
        Debug.Log($"PLAYER: Esc pressed");
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    lastTrigger = other.gameObject;
    //    if (other.gameObject.name.StartsWith("Coin"))
    //    {
    //        Debug.Log("collision coin detected!");
    //    }
    //}
}
