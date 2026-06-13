/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Make heart interact with PlayerHealth.cs, adding players health and hide heart once interacted with
 */

using System.Collections;
using UnityEngine;

public class HeartScript : MonoBehaviour, IInteractible
{
    private float delayTime = 2f;
    private AudioSource audioSource;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] private bool setFullHealth;
    [SerializeField] private int healthAmount = 30;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public string GetInteractText()
    {
        return $"E to Gain Health (+{healthAmount} HP)";
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

    private IEnumerator DelaySequence()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false); // cannot interact anymore
    }
}
