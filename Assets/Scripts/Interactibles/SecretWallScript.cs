/*
 * Author: Adam Clark
 * Date: 12 June 2026
 * Description: Disables itself once all secret buttons have been clicked
 */

using UnityEngine;

public class SecretWallScript : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
        if (scoreManager != null)
        {
            scoreManager.SecretButtonEvent += DeactivateWall;
        }
    }

    private void OnDestroy()
    {
        scoreManager.SecretButtonEvent -= DeactivateWall;
    }

    private void DeactivateWall()
    {
        gameObject.SetActive(false);
    }
}
