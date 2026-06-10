using UnityEngine;

public class CoinScript : MonoBehaviour, IInteractible
{
    [SerializeField] private int score = 10;

    public int Interact()
    {
        // Hide coin
        var render = GetComponent<MeshRenderer>();
        render.enabled = false;

        Debug.Log($"Coin, Interacted! (score: {score})");

        GetComponent<Collider>().enabled = false; // cannot interact anymore

        return score;
    }

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
