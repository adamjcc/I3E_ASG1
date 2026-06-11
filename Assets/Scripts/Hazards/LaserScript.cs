using UnityEngine;

public class LaserScript : MonoBehaviour
{
    //private bool isActive;

    [SerializeField] private float damagePerSecond = 10f;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.HealthLoss(damagePerSecond * Time.deltaTime);
        }
    }
}
