using UnityEngine;

public class CoinScript : MonoBehaviour, IInteractible
{
    [SerializeField] private int score = 10;

    public void Interact()
    {
        // Hide coin
        var render = GetComponent<MeshRenderer>();
        render.enabled = false;

        Debug.Log($"COINSCRIPT: Coin, Interacted! (score: {score})");

        GetComponent<Collider>().enabled = false; // cannot interact anymore

        ScoreManager.instance.AddScore(score);
    }
}
