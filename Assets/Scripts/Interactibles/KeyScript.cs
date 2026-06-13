/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Adds key to players inventory, and allows player to unlock locked doors
 */

using System.Collections;
using UnityEngine;

/// <summary>
/// Handles collecting a key, adding it to inventory, and showing pickup feedback.
/// </summary>
public class KeyScript : MonoBehaviour, IInteractible
{
    /// <summary>
    /// Delay before fully disabling the key so its pickup audio can finish playing.
    /// </summary>
    private float delayTime = 2f;

    /// <summary>
    /// Audio source used to play the key pickup sound.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Name used to identify this key in the inventory.
    /// </summary>
    private string keyName;

    /// <summary>
    /// Feedback text shown after the key is collected.
    /// </summary>
    private string promptText;

    /// <summary>
    /// Builds pickup text and caches the key's audio source when gameplay starts.
    /// </summary>
    private void Start()
    {
        keyName = gameObject.name;
        promptText = $"You picked up a {keyName}!";
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Gets the interaction prompt shown when the player looks at the key.
    /// </summary>
    /// <returns>Key pickup interaction text.</returns>
    public string GetInteractText()
    {
        return $"E to Pick up {keyName}";
    }

    /// <summary>
    /// Plays pickup feedback, hides the key, adds it to inventory, and starts delayed deactivation.
    /// </summary>
    public void Interact()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Hide gameObject & disable Raycast right after audio plays
        GetComponentInChildren<Renderer>().enabled = false;
        GetComponentInChildren<Collider>().enabled = false;

        InventoryManager.instance.AddItem(keyName);

        UIManager.instance.SetPromptText(true, promptText);

        StartCoroutine(DelaySequence());
    }

    /// <summary>
    /// Waits before disabling the key so its audio source is not cut off immediately.
    /// </summary>
    /// <returns>Coroutine delay instruction.</returns>
    private IEnumerator DelaySequence()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false); // cannot interact anymore
    }
}
