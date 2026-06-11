//1.Check if game is still playing.
//2.Subtract damage from currentHealth.
//3. Prevent health from going below 0.
//4. Tell UIManager to update HealthText.
//5. If health is 0, tell GameManager the player died.

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
