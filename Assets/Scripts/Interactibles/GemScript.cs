/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Increments gem and score count in ScoreManager upon player interacting with it
 */

using System.Collections;
using UnityEngine;

/// <summary>
/// Handles gem collection, score progress, win progress, and pickup feedback.
/// </summary>
public class GemScript : MonoBehaviour, IInteractible
{
    /// <summary>
    /// Delay before fully disabling the gem so its pickup audio can finish playing.
    /// </summary>
    private float delayTime = 2f;

    /// <summary>
    /// Audio source used to play the gem pickup sound.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Score awarded when this gem is collected.
    /// </summary>
    [SerializeField] private int score = 50;

    /// <summary>
    /// Name shown in the gem interaction prompt.
    /// </summary>
    private string gemName;

    /// <summary>
    /// Stores the gem name and caches the audio source when gameplay starts.
    /// </summary>
    private void Start()
    {
        gemName = gameObject.name;
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Gets the interaction prompt shown when the player looks at the gem.
    /// </summary>
    /// <returns>Gem pickup interaction text.</returns>
    public string GetInteractText()
    {
        return $"E to Get {gemName}";
    }

    /// <summary>
    /// Plays pickup feedback, hides the gem, updates gem progress, and starts delayed deactivation.
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

        ScoreManager.instance.AddGem(score);

        StartCoroutine(DelaySequence());
    }

    /// <summary>
    /// Waits before disabling the gem so its audio source is not cut off immediately.
    /// </summary>
    /// <returns>Coroutine delay instruction.</returns>
    private IEnumerator DelaySequence()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false); // cannot interact anymore
    }
}
