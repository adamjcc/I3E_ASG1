using UnityEngine;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGameState = GameState.Playing;
        ToggleCursorVisible(false);
    }

    public void TogglePause()
    {
        if (currentGameState == GameState.Playing) // when player opens Menu
        {
            currentGameState = GameState.Paused;
            ToggleCursorVisible(true);
        }
        else if (currentGameState == GameState.Paused) // when player leaves Menu
        {
            currentGameState = GameState.Playing;
            ToggleCursorVisible(false);
        }

        UIManager.instance.ToggleMenu();
        Debug.Log($"GAMEMANAGER: Pause Menu toggled - (GameState: {currentGameState})");
    }

    public void SetGameOver()
    {
        currentGameState = GameState.GameOver;
        UIManager.instance.SetGameOverMenu();
        ToggleCursorVisible(true);
    }

    private void ToggleCursorVisible(bool isVisible) // Unlock cursor when menu is visible, lock it when menu is hidden
    {
        if (isVisible == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
