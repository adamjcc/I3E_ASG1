/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Make coin score interact with ScoreManager.cs and hide coin once interacted with
 */

using System.Collections;
using UnityEngine;

public class CoinScript : MonoBehaviour, IInteractible
{
    private float delayTime = 2f;
    private AudioSource audioSource;
    [SerializeField] private int score = 10;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public string GetInteractText()
    {
        return $"E to Pick Up Coin (+{score})";
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

        ScoreManager.instance.AddScore(score);

        StartCoroutine(DelaySequence());
    }

    private IEnumerator DelaySequence()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false); // cannot interact anymore

    }
}
