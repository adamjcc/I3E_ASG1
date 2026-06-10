using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text InteractText;
    [SerializeField] private TMP_Text ScoreText;

    private int score;

    private void Update()
    {
        ScoreText.text = $"Score: {score}";
    }

    public void ToggleInteractText(bool isVisible)
    {
        if (isVisible == true)
        {
            Debug.Log($"Toggled InteractText! (isVisible: {isVisible})");
        }
        InteractText.enabled = isVisible;
    }

    public void SetScore(int newScore)
    {
        Debug.Log($"Set Score (Amt: {newScore})");
        score = newScore;
    }
}
