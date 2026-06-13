/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Make game UI work for in-game text, menu text or win/loss states
 */

using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    private AudioSource audioSourceGameOver;
    private AudioSource audioSourceMenu;

    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject GameWinPanel;
    //[SerializeField] private GameObject GameWinPanel;
    [SerializeField] private TMP_Text InteractText;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text HealthText;
    [SerializeField] private TMP_Text PromptText;
    [SerializeField] private TMP_Text InventoryText;
    [SerializeField] private TMP_Text GemGoalText;

    private int score;

    private void Awake()
    {
        if (instance != null && instance != this)
        { Destroy(gameObject); }
        else
        { instance = this; }
    }

    private void Start()
    {
        MenuPanel.SetActive(true);
        MenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameWinPanel.SetActive(false);
        InventoryText.enabled = false;
        PromptText.enabled = false;

        audioSourceGameOver = GameOverPanel.GetComponent<AudioSource>();
        audioSourceMenu = MenuPanel.GetComponent<AudioSource>();
    }

    public void ToggleMenu()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
        if (audioSourceMenu != null)
        {
            audioSourceMenu.Play();
        }
    }

    public void SetGameOverMenu()
    {
        GameOverPanel.SetActive(true);
        if (audioSourceGameOver != null)
        {
            audioSourceMenu.Play();
        }
    }

    public void SetGameWinMenu()
    {
        GameWinPanel.SetActive(true);
    }

    public void SetGemGoalText(int currentAmount, int maxAmount)
    {
        GemGoalText.text = $"{currentAmount} / {maxAmount} Gems Collected";
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

    public void SetScoreText(int newScore)
    {
        ScoreText.text = $"Score: {newScore}";
    }

    public void SetHealthText(int currentHealth, int maxHealth)
    {
        HealthText.text = $"Health: {currentHealth} / {maxHealth}";
    }

    public void SetInventoryText(List<string> inventoryList)
    {
        if (inventoryList.Count == 0)
        {
            InventoryText.text = "";
            InventoryText.enabled = false;
        }
        else
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Inventory:");
            foreach (string item in inventoryList)
            {
                text.AppendLine("- " + item);
                InventoryText.text = text.ToString();
                InventoryText.enabled = true;
            }
        }
    }
}
