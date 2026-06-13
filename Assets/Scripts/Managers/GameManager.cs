/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Manages game states, menu popup and win/loss conditions using Singleton instances
 */

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls global game states such as playing, paused, win, and game over.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Global access point for the active game manager instance.
    /// </summary>
    public static GameManager instance { get; private set; }

    /// <summary>
    /// Sets up the singleton reference and removes duplicate game manager objects.
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
    /// Possible high-level states that the game can be in.
    /// </summary>
    enum GameState { Playing, Paused, GameWin, GameOver }

    /// <summary>
    /// Current state controlling menu, cursor, and time behaviour.
    /// </summary>
    private GameState currentGameState;

    /// <summary>
    /// Starts the game in the playing state with gameplay controls active.
    /// </summary>
    void Start()
    {
        currentGameState = GameState.Playing;
        ToggleMenuConfig(false);
    }

    /// <summary>
    /// Switches between playing and paused states when the menu key is pressed.
    /// </summary>
    public void TogglePause()
    {
        if (currentGameState == GameState.Playing) // when player opens Menu
        {
            currentGameState = GameState.Paused;
            ToggleMenuConfig(true);
        }
        else if (currentGameState == GameState.Paused) // when player leaves Menu
        {
            currentGameState = GameState.Playing;
            ToggleMenuConfig(false);
        }

        UIManager.instance.ToggleMenu();
        Debug.Log($"GAMEMANAGER: Pause Menu toggled - (GameState: {currentGameState})");
    }

    /// <summary>
    /// Reloads the active scene to restart the game.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Quits the built application or stops Play Mode while running in the Unity Editor.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit(); // Closes the built game application

#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in the editor
#endif
    }

    /// <summary>
    /// Enters the game over state and displays the game over menu.
    /// </summary>
    public void SetGameOver()
    {
        currentGameState = GameState.GameOver;
        UIManager.instance.SetGameOverMenu();
        ToggleMenuConfig(true);
        Debug.Log($"GAMEMANAGER: Game Over triggered");
    }

    /// <summary>
    /// Enters the win state and displays the game win menu.
    /// </summary>
    public void SetGameWin()
    {
        currentGameState = GameState.GameWin;
        UIManager.instance.SetGameWinMenu();
        ToggleMenuConfig(true);
        Debug.Log($"GAMEMANAGER: Game Win triggered");
    }

    /// <summary>
    /// Configures cursor visibility and time scale for gameplay or menu states.
    /// </summary>
    /// <param name="isOn">True when a menu is active; false when gameplay is active.</param>
    private void ToggleMenuConfig(bool isOn)
    {
        if (isOn == true)
        {
            Cursor.lockState = CursorLockMode.None; // Unlock cursor when menu is visible, lock it when menu is hidden
            Cursor.visible = true;
            Time.timeScale = 0; // freeze time when menu is open
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1; // play time when menu is closed
        }
    }
}
