//Current score
//Number of collectibles collected
//Total collectibles
//How many collectibles are left
//Whether all collectibles are collected

using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }

    private int score = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log($"ERROR! Duplicate instance found (Instance: {instance})");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        UIManager.instance.SetScore(score);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UIManager.instance.SetScore(score);
    }
}
