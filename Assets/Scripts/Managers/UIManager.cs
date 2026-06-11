using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [SerializeField] private TMP_Text InteractText;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text HealthText;
    [SerializeField] private TMP_Text PromptText;
    [SerializeField] private TMP_Text InventoryText;

    private int score;


    private void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        ScoreText.text = $"Score: 0";
        HealthText.text = $"Health: 0";
        InventoryText.enabled = false;
        PromptText.enabled = false;
    }

    public void ToggleInteractText(bool isVisible)
    {
        if (isVisible == true)
        {
            Debug.Log($"UIMANAGER: Toggled InteractText! (isVisible: {isVisible})");
        }
        InteractText.enabled = isVisible;
    }

    public void SetScore(int newScore)
    {
        Debug.Log($"UIMANAGER: Set Score (Amt: {newScore})");
        ScoreText.text = $"Score: {newScore}";
    }
}
