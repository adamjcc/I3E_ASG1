/*
 * Author: Adam Clark
 * Date: 11 June 2026
 * Description: Updates playerHealth once player touches goblin
 */

using UnityEngine;

/// <summary>
/// Damages the player when they enter the goblin trigger and plays attack audio.
/// </summary>
public class GoblinScript : MonoBehaviour
{
    /// <summary>
    /// Audio source used to play goblin attack feedback.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Damage dealt when the player enters the goblin trigger.
    /// </summary>
    [SerializeField] private float damagePerHit = 20f;

    /// <summary>
    /// Minimum time between goblin damage hits.
    /// </summary>
    [SerializeField] private float damageCooldown = 1f;

    /// <summary>
    /// Next game time at which the goblin is allowed to damage the player.
    /// </summary>
    private float nextDamageTime = 0f;

    /// <summary>
    /// Caches the goblin's audio source when gameplay starts.
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Applies damage when the player enters the trigger and the cooldown has expired.
    /// </summary>
    /// <param name="other">Collider that entered the goblin trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            if (Time.time >= nextDamageTime)
            {
                playerHealth.HealthLoss(damagePerHit);
                nextDamageTime = Time.time + damageCooldown;
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
        }
    }
}
