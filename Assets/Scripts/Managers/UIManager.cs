using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject GameOverPanel;
    //[SerializeField] private GameObject GameWinPanel;
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
        MenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        InventoryText.enabled = false;
        PromptText.enabled = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToggleMenu()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
    }

    public void SetGameOverMenu()
    {
        GameOverPanel.SetActive(true);
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

    public void SetScore(int newScore)
    {
        ScoreText.text = $"Score: {newScore}";
    }

    public void SetHealthText(int currentHealth, int maxHealth)
    {
        HealthText.text = $"Health: {currentHealth} / {maxHealth}";
    }
}
