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
