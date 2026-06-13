/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Make coin score interact with ScoreManager.cs and hide coin once interacted with
 */

using UnityEngine;

public class CoinScript : MonoBehaviour, IInteractible
{
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

        // Hide coin
        GetComponentInChildren<Renderer>().enabled = false;

        ScoreManager.instance.AddScore(score);

        gameObject.SetActive(false); // cannot interact anymore
    }
}
