/*
 * Author: Adam Clark
 * Date: 12 June 2026
 * Description: Damages player when touched and updates PlayerHealth
 */

using UnityEngine;

/// <summary>
/// Damages the player over time while they stay inside the toxic gas trigger.
/// </summary>
public class ToxicGasScript : MonoBehaviour
{
    /// <summary>
    /// Damage applied each second while the player remains inside the gas.
    /// </summary>
    [SerializeField] private float damagePerSecond = 40f;

    /// <summary>
    /// Applies continuous damage while a player health component stays inside the trigger.
    /// </summary>
    /// <param name="other">Collider currently inside the gas trigger.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.HealthLoss(damagePerSecond * Time.deltaTime);
        }
    }
}
