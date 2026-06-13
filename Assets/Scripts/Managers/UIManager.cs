/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Make game UI work for in-game text, menu text or win/loss states
 */

using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

/// <summary>
/// Updates gameplay UI text, menus, and menu-related audio feedback.
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Global access point for the active UI manager instance.
    /// </summary>
    public static UIManager instance { get; private set; }

    /// <summary>
    /// Audio source used by the game over panel.
    /// </summary>
    private AudioSource audioSourceGameOver;

    /// <summary>
    /// Audio source used by the pause menu panel.
    /// </summary>
    private AudioSource audioSourceMenu;

    /// <summary>
    /// Pause menu panel shown when gameplay is paused.
    /// </summary>
    [SerializeField] private GameObject MenuPanel;

    /// <summary>
    /// Panel shown when the player loses.
    /// </summary>
    [SerializeField] private GameObject GameOverPanel;

    /// <summary>
    /// Text shown on the ending screen to display final score.
    /// </summary>
    [SerializeField] private TMP_Text EndScoreText;

    /// <summary>
    /// Panel shown when the player wins.
    /// </summary>
    [SerializeField] private GameObject GameWinPanel;
    //[SerializeField] private GameObject GameWinPanel;

    /// <summary>
    /// Text that tells the player what they can interact with.
    /// </summary>
    [SerializeField] private TMP_Text InteractText;

    /// <summary>
    /// Text displaying the current score.
    /// </summary>
    [SerializeField] private TMP_Text ScoreText;

    /// <summary>
    /// Text displaying current and maximum health.
    /// </summary>
    [SerializeField] private TMP_Text HealthText;

    /// <summary>
    /// Text used for short feedback messages such as locked doors or pickups.
    /// </summary>
    [SerializeField] private TMP_Text PromptText;

    /// <summary>
    /// Text showing collected inventory items.
    /// </summary>
    [SerializeField] private TMP_Text InventoryText;

    /// <summary>
    /// Text showing how many gems have been collected.
    /// </summary>
    [SerializeField] private TMP_Text GemGoalText;

    /// <summary>
    /// Sets up the singleton reference and removes duplicate UI manager objects.
    /// </summary>
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log($"ERROR! Duplicate instance found (Instance: {instance})");
            Destroy(gameObject);
        }
        else
        { instance = this; }
    }

    /// <summary>
    /// Hides menus and prompt UI at the start of play and caches menu audio sources.
    /// </summary>
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

    /// <summary>
    /// Shows or hides the pause menu and plays menu audio feedback.
    /// </summary>
    public void ToggleMenu()
    {
        if (MenuPanel.activeInHierarchy)
        {
            if (audioSourceMenu != null)
            {
                audioSourceMenu.Play();
            }
            MenuPanel.SetActive(!MenuPanel.activeSelf);
        }
        else
        {
            MenuPanel.SetActive(!MenuPanel.activeSelf);
            if (audioSourceMenu != null)
            {
                audioSourceMenu.Play();
            }
        }
    }

    /// <summary>
    /// Shows the game over menu and plays its audio feedback.
    /// </summary>
    public void SetGameOverMenu()
    {
        GameOverPanel.SetActive(true);
        if (audioSourceGameOver != null)
        {
            audioSourceGameOver.Play();
        }
    }

    /// <summary>
    /// Shows the game win menu and displays the player's final score.
    /// </summary>
    public void SetGameWinMenu()
    {
        GameWinPanel.SetActive(true);
        EndScoreText.text = $"Score: {ScoreManager.instance.GetScore()}";
    }

    /// <summary>
    /// Updates the gem collection progress text.
    /// </summary>
    /// <param name="currentAmount">Number of gems collected.</param>
    /// <param name="maxAmount">Total number of gems in the scene.</param>
    public void SetGemGoalText(int currentAmount, int maxAmount)
    {
        GemGoalText.text = $"{currentAmount} / {maxAmount} Gems Collected";
    }

    /// <summary>
    /// Shows or hides the interaction prompt and updates its message.
    /// </summary>
    /// <param name="isVisible">Whether the interaction prompt should be visible.</param>
    /// <param name="interactMessage">Message to display when visible.</param>
    public void SetInteractText(bool isVisible, string interactMessage = "")
    {
        InteractText.enabled = isVisible;
        InteractText.text = interactMessage;
    }

    /// <summary>
    /// Shows or hides the general prompt text and updates its message.
    /// </summary>
    /// <param name="isVisible">Whether the prompt should be visible.</param>
    /// <param name="promptMessage">Message to display when visible.</param>
    public void SetPromptText(bool isVisible, string promptMessage = "")
    {
        PromptText.enabled = isVisible;
        PromptText.text = promptMessage;
    }

    /// <summary>
    /// Updates the score text.
    /// </summary>
    /// <param name="newScore">Score value to display.</param>
    public void SetScoreText(int newScore)
    {
        ScoreText.text = $"Score: {newScore}";
    }

    /// <summary>
    /// Updates the health text.
    /// </summary>
    /// <param name="currentHealth">Current player health.</param>
    /// <param name="maxHealth">Maximum player health.</param>
    public void SetHealthText(int currentHealth, int maxHealth)
    {
        HealthText.text = $"Health: {currentHealth} / {maxHealth}";
    }

    /// <summary>
    /// Updates the inventory text from the current inventory list.
    /// </summary>
    /// <param name="inventoryList">List of inventory item names to display.</param>
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
