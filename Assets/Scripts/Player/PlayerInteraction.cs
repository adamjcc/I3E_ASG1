/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Handles projecting a raycast from the screen center to find and execute IInteractible objects
 */

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f; // how close player needs to be for raycast to fire
    [SerializeField] private LayerMask raycastLayer; // raycast can ONLY hit this layer of gameobj

    [SerializeField] private UIManager MyUIManager;

    private IInteractible currentInteractible; // saves objs that can be interacted with

    int score = 0;

    private void Start()
    {
        Debug.Log(raycastLayer.value);
    }

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
                Debug.Log($"Raycast hit Object! (Obj: {currentInteractible})!");
                MyUIManager.ToggleInteractText(true);
            }
            else
            {
                currentInteractible = null;
                MyUIManager.ToggleInteractText(false);
            }
        }
        else
        {
            currentInteractible = null;
            MyUIManager.ToggleInteractText(false);
        }
    }

    void OnInteract(InputValue value)
    {
        Debug.Log("E pressed (interact)");
        
        if (currentInteractible != null)
        {
            score += currentInteractible.Interact();
            MyUIManager.SetScore(score);
            Debug.Log($"Score added + Menu changed (Interactible: {currentInteractible} | Score: {score})");
        }
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
