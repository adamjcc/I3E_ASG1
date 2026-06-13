/*
 * Author: Adam Clark
 * Date: 11 June 2026
 * Description: Updates playerHealth once player touches laser with collisions
 */

using UnityEngine;

/// <summary>
/// Damages the player over time while they stay inside the laser trigger.
/// </summary>
public class LaserScript : MonoBehaviour
{
    /// <summary>
    /// Damage applied each second while the player remains in the laser.
    /// </summary>
    [SerializeField] private float damagePerSecond = 20f;

    /// <summary>
    /// Applies continuous damage while a player health component stays inside the trigger.
    /// </summary>
    /// <param name="other">Collider currently inside the laser trigger.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.HealthLoss(damagePerSecond * Time.deltaTime);
        }
    }

    /// <summary>
    /// Disables the laser object.
    /// </summary>
    private void DeactivateLaser()
    {
        gameObject.SetActive(false);
    }
}
