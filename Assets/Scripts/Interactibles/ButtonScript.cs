/*
 * Author: Adam Clark
 * Date: 11 June 2026
 * Description: Triggers deactivation of lasers or secret walls once pressed using Unity Events
 */

using UnityEngine;

/// <summary>
/// Handles button interaction, secret button progress, linked events, prompt feedback, and button audio.
/// </summary>
public class ButtonScript : MonoBehaviour, IInteractible
{
    /// <summary>
    /// Audio source used to play button press feedback.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Whether this button contributes to the secret button counter instead of invoking the normal button event.
    /// </summary>
    [SerializeField] private bool isSecretButton;

    /// <summary>
    /// Feedback text shown when the button is pressed.
    /// </summary>
    private string promptText = "Boop!";

    /// <summary>
    /// Event invoked when a non-secret button is pressed.
    /// </summary>
    public System.Action OnButtonPressed;

    /// <summary>
    /// Caches the button's audio source when gameplay starts.
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Gets the interaction prompt shown when the player looks at the button.
    /// </summary>
    /// <returns>Button interaction text.</returns>
    public string GetInteractText()
    {
        return "E to Press Button";
    }

    /// <summary>
    /// Applies secret or normal button behaviour and plays button feedback.
    /// </summary>
    public void Interact()
    {
        if (isSecretButton == true)
        {
            ScoreManager.instance.AddSecretButton(gameObject.name);
        }
        else
        {
            OnButtonPressed?.Invoke();
        }
        UIManager.instance.SetPromptText(true, promptText);
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
