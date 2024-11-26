using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    mainMenu=0,
    gamePlay=1,
    settings=2,
    victory=3,
    fail=4,
}

public class GameStateManager : Singleton<GameStateManager> 
{
    private GameState currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.OpenUI<CanvasMainMenu>();
        currentState = GameState.mainMenu;
    }


    public void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case GameState.mainMenu:
                Time.timeScale = 0;
                break;
            case GameState.gamePlay:
                Time.timeScale = 1;
                break;
            case GameState.settings:
                Time.timeScale = 0;
                break;
            case GameState.victory:
                break;
            case GameState.fail:

                break;

        }
    }


    public bool IsGameState(GameState state)
    {
        return currentState == state;
    }
}
