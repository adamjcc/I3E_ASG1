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

    public void SetInteractText(bool isVisible, string interactMessage = "")
    {
        InteractText.enabled = isVisible;
        InteractText.text = interactMessage;
    }

    public void SetPromptText(bool isVisible, string promptMessage = "")
    {
        PromptText.enabled = isVisible;
        PromptText.text = promptMessage;
    }

    public void SetPromptText(string interactMessage)
    {

    }

    public void SetScore(int newScore)
    {
        Debug.Log($"UIMANAGER: Set Score (Amt: {newScore})");
        ScoreText.text = $"Score: {newScore}";
    }
}
