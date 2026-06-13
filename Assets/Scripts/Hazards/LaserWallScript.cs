/*
 * Author: Adam Clark
 * Date: 11 June 2026
 * Description: Updates playerHealth once player touches laser with collisions, and deactivates itself once event is sent from ButtonScript
 */

using UnityEngine;

/// <summary>
/// Damages the player on contact and can be deactivated by a linked button event.
/// </summary>
public class LaserWallScript : MonoBehaviour
{
    /// <summary>
    /// Damage applied each second while the player remains in contact with the laser wall.
    /// </summary>
    [SerializeField] private float damagePerSecond = 20f;

    /// <summary>
    /// Button that deactivates this laser wall when pressed.
    /// </summary>
    [SerializeField] private ButtonScript buttonTrigger;

    /// <summary>
    /// Subscribes to the linked button event when gameplay starts.
    /// </summary>
    private void Start()
    {
        if (buttonTrigger != null)
        {
            buttonTrigger.OnButtonPressed += DeactivateLaser;
        }
    }

    /// <summary>
    /// Unsubscribes from the linked button event before this object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        buttonTrigger.OnButtonPressed -= DeactivateLaser;
    }

    /// <summary>
    /// Disables the laser wall object.
    /// </summary>
    private void DeactivateLaser()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Applies continuous damage while the player remains in collision with the laser wall.
    /// </summary>
    /// <param name="collision">Collision data for the object touching the laser wall.</param>
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.HealthLoss(damagePerSecond * Time.deltaTime);
        }
    }
}
