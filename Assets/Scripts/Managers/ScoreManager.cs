/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Manages & stores score and adding gems for game using Singleton instances
 */

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tracks player score, gem collection progress, and secret button progress.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Global access point for the active score manager instance.
    /// </summary>
    public static ScoreManager instance { get; private set; }

    /// <summary>
    /// Sets up the singleton reference and removes duplicate score manager objects.
    /// </summary>
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

    /// <summary>
    /// Number of gems collected by the player so far.
    /// </summary>
    private int currentGemAmount = 0;

    /// <summary>
    /// Total number of gem objects detected in the scene.
    /// </summary>
    private int maxGemAmount;

    /// <summary>
    /// Current player score.
    /// </summary>
    private int score = 0;

    /// <summary>
    /// Unique secret button names that have already been found.
    /// </summary>
    private List<string> secretButtonsFound = new List<string>();

    /// <summary>
    /// Event fired after the required number of secret buttons has been pressed.
    /// </summary>
    public System.Action SecretButtonEvent;

    /// <summary>
    /// Counts scene gems and initialises score and gem UI.
    /// </summary>
    private void Start()
    {
        GemScript[] gemsInScene = FindObjectsByType<GemScript>(FindObjectsSortMode.None);
        maxGemAmount = gemsInScene.Length;
        UIManager.instance.SetGemGoalText(currentGemAmount, maxGemAmount);
        UIManager.instance.SetScoreText(score);
    }

    /// <summary>
    /// Gets the current player score.
    /// </summary>
    /// <returns>Current score value.</returns>
    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// Adds score from a collectible and updates the score UI.
    /// </summary>
    /// <param name="newScore">Score amount to add.</param>
    public void AddScore(int newScore)
    {
        score += newScore;
        UIManager.instance.SetScoreText(score);
    }

    /// <summary>
    /// Adds gem score, increments gem progress, and checks the win condition.
    /// </summary>
    /// <param name="newScore">Score amount awarded by the collected gem.</param>
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

    /// <summary>
    /// Tracks a secret button press and fires the secret button event once enough unique buttons are found.
    /// </summary>
    /// <param name="buttonName">Name of the secret button that was pressed.</param>
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
