using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    mainMenu = 0,
    gamePlay = 3,
    selectLevel = 5,
    settings = 8,
    victory = 10,
    fail = 12,

}

public class GameStateManager : Singleton<GameStateManager>
{
    private GameState curentState;

    // Start is called before the first frame update
    void Start()
    {
        curentState = GameState.mainMenu;
    }


    public void ChangeState(GameState newState)
    {
        curentState = newState;

        switch (newState)
        {
            case GameState.gamePlay:

                break;
            case GameState.selectLevel:
                break;
            case GameState.settings:
                break;
            case GameState.victory:
                break;
            case GameState.mainMenu:
                break;
        }
    }


    public bool IsGameState(GameState state)
    {
        return curentState == state;
    }
}
