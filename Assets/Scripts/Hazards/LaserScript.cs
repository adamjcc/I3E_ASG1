/*
 * Author: Adam Clark
 * Date: 11 June 2026
 * Description: Updates playerHealth once player touches laser with collisions
 */

using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] private float damagePerSecond = 20f;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.HealthLoss(damagePerSecond * Time.deltaTime);
        }
    }

    private void DeactivateLaser()
    {
        gameObject.SetActive(false);
    }
}
