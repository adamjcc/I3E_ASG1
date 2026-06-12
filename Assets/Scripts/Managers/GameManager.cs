using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log($"ERROR! Duplicate instance found (Instance: {instance})");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    enum GameState { Playing, Paused, GameWin, GameOver }
    private GameState currentGameState;

    void Start()
    {
        currentGameState = GameState.Playing;
        ToggleMenuConfig(false);
    }

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
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit(); // Closes the built game application

        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in the editor
        #endif
    }

    public void SetGameOver()
    {
        currentGameState = GameState.GameOver;
        UIManager.instance.SetGameOverMenu();
        ToggleMenuConfig(true);
        Debug.Log($"GAMEMANAGER: Game Over triggered");
    }

    public void SetGameWin()
    {
        currentGameState = GameState.GameWin;
        UIManager.instance.SetGameWinMenu();
        ToggleMenuConfig(true);
        Debug.Log($"GAMEMANAGER: Game Win triggered");
    }

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
