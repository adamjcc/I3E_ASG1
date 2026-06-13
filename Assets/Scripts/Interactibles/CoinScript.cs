/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Make coin score interact with ScoreManager.cs and hide coin once interacted with
 */

using System.Collections;
using UnityEngine;

/// <summary>
/// Adds score when collected, plays pickup audio, then hides and disables the coin after a delay.
/// </summary>
public class CoinScript : MonoBehaviour, IInteractible
{
    /// <summary>
    /// Delay before fully disabling the coin so its pickup audio can finish playing.
    /// </summary>
    private float delayTime = 2f;

    /// <summary>
    /// Audio source used to play the coin pickup sound.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Score awarded when this coin is collected.
    /// </summary>
    [SerializeField] private int score = 10;

    /// <summary>
    /// Caches the coin's audio source when gameplay starts.
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Gets the interaction prompt shown when the player looks at the coin.
    /// </summary>
    /// <returns>Coin pickup interaction text.</returns>
    public string GetInteractText()
    {
        return $"E to Pick Up Coin (+{score})";
    }

    /// <summary>
    /// Plays pickup feedback, hides the coin, awards score, and starts delayed deactivation.
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

        ScoreManager.instance.AddScore(score);

        StartCoroutine(DelaySequence());
    }

    /// <summary>
    /// Waits before disabling the coin so its audio source is not cut off immediately.
    /// </summary>
    /// <returns>Coroutine delay instruction.</returns>
    private IEnumerator DelaySequence()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false); // cannot interact anymore

    }
}
