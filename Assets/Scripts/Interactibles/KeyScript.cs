/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Adds key to players inventory, and allows player to unlock locked doors
 */

using System.Collections;
using UnityEngine;

public class KeyScript : MonoBehaviour, IInteractible
{
    private float delayTime = 2f;
    private AudioSource audioSource;
    private string keyName;
    private string promptText;

    private void Start()
    {
        keyName = gameObject.name;
        promptText = $"You picked up a {keyName}!";
        audioSource = GetComponent<AudioSource>();
    }

    public string GetInteractText()
    {
        return $"E to Pick up {keyName}";
    }

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

    private IEnumerator DelaySequence()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false); // cannot interact anymore
    }
}
