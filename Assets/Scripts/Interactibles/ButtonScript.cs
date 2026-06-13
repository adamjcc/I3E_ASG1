/*
 * Author: Adam Clark
 * Date: 11 June 2026
 * Description: Triggers deactivation of lasers or secret walls once pressed using Unity Events
 */

using UnityEngine;

public class ButtonScript : MonoBehaviour, IInteractible
{
    private AudioSource audioSource;
    [SerializeField] private bool isSecretButton;
    private string promptText = "Boop!";

    public System.Action OnButtonPressed;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public string GetInteractText()
    {
        return "E to Press Button";
    }

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
