/*
 * Author: Adam Clark
 * Date: 11 June 2026
 * Description: Updates playerHealth once player touches laser with collisions, and deactivates itself once event is sent from ButtonScript
 */

using UnityEngine;

public class LaserWallScript : MonoBehaviour
{
    [SerializeField] private float damagePerSecond = 20f;
    [SerializeField] private ButtonScript buttonTrigger;

    private void Start()
    {
        if (buttonTrigger != null)
        {
            buttonTrigger.OnButtonPressed += DeactivateLaser;
        }
    }

    private void OnDestroy()
    {
        buttonTrigger.OnButtonPressed -= DeactivateLaser;
    }

    private void DeactivateLaser()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.HealthLoss(damagePerSecond * Time.deltaTime);
        }
    }
}
