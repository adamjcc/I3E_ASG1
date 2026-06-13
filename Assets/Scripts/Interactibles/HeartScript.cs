/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Make heart interact with PlayerHealth.cs, adding players health and hide heart once interacted with
 */

using System.Collections;
using UnityEngine;

/// <summary>
/// Restores player health when collected, plays pickup audio, then hides and disables the heart.
/// </summary>
public class HeartScript : MonoBehaviour, IInteractible
{
    /// <summary>
    /// Delay before fully disabling the heart so its pickup audio can finish playing.
    /// </summary>
    private float delayTime = 2f;

    /// <summary>
    /// Audio source used to play the heart pickup sound.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Player health component that receives the healing effect.
    /// </summary>
    [SerializeField] PlayerHealth playerHealth;

    /// <summary>
    /// Determines whether the heart sets health directly instead of adding health.
    /// </summary>
    [SerializeField] private bool setFullHealth;

    /// <summary>
    /// Health amount restored or assigned when this heart is collected.
    /// </summary>
    [SerializeField] private int healthAmount = 30;

    /// <summary>
    /// Caches the heart's audio source when gameplay starts.
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Gets the interaction prompt shown when the player looks at the heart.
    /// </summary>
    /// <returns>Heart pickup interaction text.</returns>
    public string GetInteractText()
    {
        return $"E to Gain Health (+{healthAmount} HP)";
    }

    /// <summary>
    /// Plays pickup feedback, hides the heart, restores health, and starts delayed deactivation.
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

        if (setFullHealth == false)
        {
            playerHealth.HealthGain(healthAmount);
        }
        else
        {
            playerHealth.SetHealth(healthAmount);
        }

        StartCoroutine(DelaySequence());
    }

    /// <summary>
    /// Waits before disabling the heart so its audio source is not cut off immediately.
    /// </summary>
    /// <returns>Coroutine delay instruction.</returns>
    private IEnumerator DelaySequence()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false); // cannot interact anymore
    }
}
