/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Stores player health and health logic
 */

using UnityEngine;

/// <summary>
/// Stores the player's health values and updates health-related UI and game state.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// Highest health value the player can normally have.
    /// </summary>
    [SerializeField] private float maxHealth = 100f;

    /// <summary>
    /// Player's current health value during gameplay.
    /// </summary>
    [SerializeField] private float currentHealth = 100f;

    /// <summary>
    /// Initialises the health UI with the starting health values.
    /// </summary>
    private void Start()
    {
        UIManager.instance.SetHealthText((int)(currentHealth), (int)(maxHealth));
    }

    /// <summary>
    /// Reduces player health and triggers game over when health reaches zero.
    /// </summary>
    /// <param name="amount">Amount of health to subtract.</param>
    public void HealthLoss(float amount)
    {
        currentHealth -= amount;
        UIManager.instance.SetHealthText((int)(currentHealth), (int)(maxHealth));

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager.instance.SetGameOver();
        }
    }

    /// <summary>
    /// Increases player health without allowing it to exceed maximum health.
    /// </summary>
    /// <param name="amount">Amount of health to restore.</param>
    public void HealthGain(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIManager.instance.SetHealthText((int)(currentHealth), (int)(maxHealth));
    }

    /// <summary>
    /// Sets the player's current health directly and updates the health UI.
    /// </summary>
    /// <param name="amount">New health value to assign.</param>
    public void SetHealth(float amount)
    {
        currentHealth = amount;

        UIManager.instance.SetHealthText((int)(currentHealth), (int)(maxHealth));
    }
}
