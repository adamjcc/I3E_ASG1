//Current score
//Number of collectibles collected
//Total collectibles
//How many collectibles are left
//Whether all collectibles are collected

using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log($"ERROR! Duplicate instance found (Instance: {instance})");
            Destroy(gameObject);
        }
        else
        { instance = this; }
    }

    private int currentGemAmount = 0;
    private int maxGemAmount;
    private int score = 0;

    private List<string> secretButtonsFound = new List<string>();
    public System.Action SecretButtonEvent;

    private void Start()
    {
        GemScript[] gemsInScene = FindObjectsByType<GemScript>(FindObjectsSortMode.None);
        maxGemAmount = gemsInScene.Length;
        UIManager.instance.SetGemGoalText(currentGemAmount, maxGemAmount);
        UIManager.instance.SetScoreText(score);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UIManager.instance.SetScoreText(score);
    }

    public void AddGem(int newScore)
    {
        score += newScore;
        currentGemAmount += 1;

        UIManager.instance.SetScoreText(score);
        UIManager.instance.SetGemGoalText(currentGemAmount, maxGemAmount);

        if (currentGemAmount == maxGemAmount)
        {
            GameManager.instance.SetGameWin();
        }
    }

    public void AddSecretButton(string buttonName)
    {
        if (secretButtonsFound.Contains(buttonName) == false)
        {
            secretButtonsFound.Add(buttonName);
            if (secretButtonsFound.Count == 2)
            {
                SecretButtonEvent?.Invoke();
            }
        }
    }
}
