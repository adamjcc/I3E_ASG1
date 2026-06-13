/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Trigger DoorAnimation when door is interacted with, and show lock visual when locked
 */

using UnityEngine;

/// <summary>
/// Controls locked and unlocked door interaction, door animation, lock visuals, and door audio.
/// </summary>
public class DoorScript : MonoBehaviour, IInteractible
{
    /// <summary>
    /// Audio source used for door open and close feedback.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Visual object shown when the door is locked.
    /// </summary>
    [SerializeField] private GameObject lockVisual;

    /// <summary>
    /// Whether this door starts locked.
    /// </summary>
    [SerializeField] private bool isLocked = false;

    /// <summary>
    /// Key object required to unlock this door, if any.
    /// </summary>
    [SerializeField] private GameObject keyRequired;

    /// <summary>
    /// Name of the required key used for inventory checks.
    /// </summary>
    private string keyRequiredName;

    /// <summary>
    /// Message shown when the player tries to open the door without the required key.
    /// </summary>
    private string promptLockedText = "Door Locked!";

    /// <summary>
    /// Message shown when the player successfully unlocks the door.
    /// </summary>
    private string promptUnlockedText = "Door Unlocked!";

    /// <summary>
    /// Tracks whether the door is currently closed.
    /// </summary>
    private bool isClosed = true;

    /// <summary>
    /// Caches audio, configures lock visuals, and stores required key data.
    /// </summary>
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

    /// <summary>
    /// Gets the correct interaction prompt based on the door's lock and open state.
    /// </summary>
    /// <returns>Door interaction text.</returns>
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

    /// <summary>
    /// Attempts to unlock the door if needed, then opens or closes it.
    /// </summary>
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

    /// <summary>
    /// Toggles door animator states when the door is unlocked.
    /// </summary>
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

    /// <summary>
    /// Closes the door when it is unlocked and currently open.
    /// </summary>
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
