using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameState gameState;

    private void Start()
    {
        gameState = new GameState();
        gameState.SetGameState(GameStateEnum.Menu);
        LoadMainMenu();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        gameState.SetGameState(GameStateEnum.Playing);
        SceneManager.LoadScene("Game");
    }

    public void EndGame()
    {
        gameState.SetGameState(GameStateEnum.GameOver);
        SceneManager.LoadScene("MainMenu");
    }

    public GameState GetGameState()
    {
        return gameState;
    }
}
