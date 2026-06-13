/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Stores player health and health logic
 */

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth = 100f;

    private void Start()
    {
        UIManager.instance.SetHealthText((int)(currentHealth), (int)(maxHealth));
    }

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
    public void HealthGain(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIManager.instance.SetHealthText((int)(currentHealth), (int)(maxHealth));
    }
}
