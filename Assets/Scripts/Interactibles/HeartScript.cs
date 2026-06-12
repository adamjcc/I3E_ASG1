using UnityEngine;

public class HeartScript : MonoBehaviour, IInteractible
{
    private AudioSource audioSource;
    [SerializeField] PlayerHealth playerHealth;
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

        // Hide heart
        GetComponentInChildren<Renderer>().enabled = false;

        playerHealth.HealthGain(healthAmount);

        gameObject.SetActive(false);
    }
}
