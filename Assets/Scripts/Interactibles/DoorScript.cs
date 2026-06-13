/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Trigger DoorAnimation when door is interacted with, and show lock visual when locked
 */

using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractible
{
    private AudioSource audioSource;
    [SerializeField] private GameObject lockVisual;
    [SerializeField] private bool isLocked = false;
    [SerializeField] private GameObject keyRequired;
    private string keyRequiredName;
    private string promptLockedText = "Door Locked!";
    private string promptUnlockedText = "Door Unlocked!";
    private bool isClosed = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        lockVisual.SetActive(isLocked); // show Lock visual if door is locked, and vise versa
        if (keyRequired == null)
        {
            keyRequiredName = "";
        }
        else
        {
            keyRequiredName = keyRequired.name;
            promptLockedText = $"Door Locked! ({keyRequiredName} required)";
        }
    }

    public string GetInteractText()
    {
        if (isClosed == true)
        {
            if (isLocked == true)
            {
                return "E to Unlock Door";
            }
            else
            {
                return "E to Open Door";
            }
        }
        else
        {
            return "E to Close Door";
        }
    }

    public void Interact()
    {
        if (isLocked == true && InventoryManager.instance.HasItem(keyRequiredName) == false)
        {
            UIManager.instance.SetPromptText(true, promptLockedText);
        }
        else
        {
            if (isLocked == true)
            {
                UIManager.instance.SetPromptText(true, promptUnlockedText);
                InventoryManager.instance.RemoveItem(keyRequiredName);
                isLocked = false;
                lockVisual.SetActive(false);
            }

            OpenCloseDoor();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    private void OpenCloseDoor()
    {
        if (isLocked == false)
        {
            var animatorComponent = GetComponentsInChildren<Animator>();

            foreach (var animator in animatorComponent)
            { animator.SetBool("IsOpen", isClosed); }

            isClosed = !isClosed;
        }
    }

    public void CloseDoor()
    {
        if (isLocked == false && isClosed == false)
        {
            var animatorComponent = GetComponentsInChildren<Animator>();

            foreach (var animator in animatorComponent)
            { animator.SetBool("IsOpen", isClosed); }

            isClosed = !isClosed;
        }
    }
}