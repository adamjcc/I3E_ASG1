using UnityEngine;

public class GemScript : MonoBehaviour, IInteractible
{
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

        // Hide gem
        GetComponentInChildren<Renderer>().enabled = false;

        ScoreManager.instance.AddGem(score);

        gameObject.SetActive(false); // cannot interact anymore
    }
}
