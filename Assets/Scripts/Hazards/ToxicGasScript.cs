/*
 * Author: Adam Clark
 * Date: 12 June 2026
 * Description: Damages player when touched and updates PlayerHealth
 */

using UnityEngine;

public class ToxicGasScript : MonoBehaviour
{
    [SerializeField] private float damagePerSecond = 40f;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.HealthLoss(damagePerSecond * Time.deltaTime);
        }
    }
}
