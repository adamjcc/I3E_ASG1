/*
 * Author: Adam Clark
 * Date: 11 June 2026
 * Description: Updates playerHealth once player touches goblin
 */

using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private float damagePerHit = 20f;
    [SerializeField] private float damageCooldown = 1f;
    private float nextDamageTime = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
