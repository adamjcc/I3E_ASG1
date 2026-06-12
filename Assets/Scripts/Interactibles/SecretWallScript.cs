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
