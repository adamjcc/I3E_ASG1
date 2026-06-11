using UnityEngine;

public class CoinScript : MonoBehaviour, IInteractible
{
    [SerializeField] private int score = 10;

    public string GetInteractText()
    {
        return "E to Pick Up Coin";
    }

    public void Interact()
    {
        // Hide coin
        GetComponentInChildren<Renderer>().enabled = false;

        ScoreManager.instance.AddScore(score);

        gameObject.SetActive(false); // cannot interact anymore

        Debug.Log($"COINSCRIPT: Coin, Interacted + Hidden! (score: {score})");
    }
}
