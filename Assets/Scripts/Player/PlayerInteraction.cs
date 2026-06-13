/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Handles player interactions with Raycasting, as well as ensuring key inputs work properly (e.g. E, Esc)
 */

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f; // how close player needs to be for raycast to fire
    [SerializeField] private LayerMask raycastLayer; // raycast can ONLY hit this layer of gameobj

    private IInteractible currentInteractible; // saves objs that can be interacted with

    private void Update()
    {
        PerformRaycast();
    }

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

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DoorScript>(out DoorScript doorScript))
        {
            doorScript.CloseDoor();
        }
    }

    private void OnInteract(InputValue value)
    {
        Debug.Log("PLAYER: E pressed (interact)");

        if (currentInteractible != null)
        {
            currentInteractible.Interact();
            Debug.Log($"PLAYER: SUCCESS - Interacted with Interactible: {currentInteractible}");
        }
    }

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
