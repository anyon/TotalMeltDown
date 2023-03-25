using System;

public class GameState
{
    public int score;
    public int lives;
    public bool isPaused;
    GameStateEnum stateEnum = GameStateEnum.Playing;

    public GameState()
    {

    }

    public GameState(int initialScore, int initialLives, bool isGamePaused)
    {
        score = initialScore;
        lives = initialLives;
        isPaused = isGamePaused;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public void DecreaseLives()
    {
        lives--;
    }

    public void PauseGame()
    {
        isPaused = true;
    }

    public void UnpauseGame()
    {
        isPaused = false;
    }

    internal void SetGameState(GameStateEnum stateMenu)
    {
        stateEnum = stateMenu;
    }
}
