using UnityEngine;

public class GemScript : MonoBehaviour, IInteractible
{
    [SerializeField] private int score = 50;
    private string gemName;

    private void Start()
    {
        gemName = gameObject.name;
    }

    public string GetInteractText()
    {
        return $"E to Get {gemName}";
    }

    public void Interact()
    {
        // Hide gem
        GetComponentInChildren<Renderer>().enabled = false;

        ScoreManager.instance.AddGem(score);

        gameObject.SetActive(false); // cannot interact anymore
    }
}
