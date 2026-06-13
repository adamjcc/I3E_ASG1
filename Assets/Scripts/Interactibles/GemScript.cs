/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Increments gem and score count in ScoreManager upon player interacting with it
 */

using System.Collections;
using UnityEngine;

public class GemScript : MonoBehaviour, IInteractible
{
    private float delayTime = 2f;
    private AudioSource audioSource;
    [SerializeField] private int score = 50;
    private string gemName;

    private void Start()
    {
        gemName = gameObject.name;
        audioSource = GetComponent<AudioSource>();
    }

    public string GetInteractText()
    {
        return $"E to Get {gemName}";
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

        ScoreManager.instance.AddGem(score);

        StartCoroutine(DelaySequence());
    }

    private IEnumerator DelaySequence()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false); // cannot interact anymore
    }
}
