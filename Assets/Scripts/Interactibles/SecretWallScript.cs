/*
 * Author: Adam Clark
 * Date: 12 June 2026
 * Description: Disables itself once all secret buttons have been clicked to reveal hidden entrance to 3rd room
 */

using UnityEngine;

/// <summary>
/// Hides a secret wall after the required secret button event is triggered.
/// </summary>
public class SecretWallScript : MonoBehaviour
{
    /// <summary>
    /// Score manager that publishes the secret button event.
    /// </summary>
    [SerializeField] private ScoreManager scoreManager;

    /// <summary>
    /// Subscribes to the secret button event when gameplay starts.
    /// </summary>
    private void Start()
    {
        if (scoreManager != null)
        {
            scoreManager.SecretButtonEvent += DeactivateWall;
        }
    }

    /// <summary>
    /// Unsubscribes from the secret button event before this object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        scoreManager.SecretButtonEvent -= DeactivateWall;
    }

    /// <summary>
    /// Disables the wall to reveal the hidden path.
    /// </summary>
    private void DeactivateWall()
    {
        gameObject.SetActive(false);
    }
}
