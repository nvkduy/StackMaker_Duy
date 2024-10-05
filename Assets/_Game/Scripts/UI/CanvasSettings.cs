using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasSettings : UICanvas
{
    [SerializeField] GameObject[] buttons;

    public void SetState(UICanvas canvas)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        if (canvas is CanvasMainMenu)
        {
            buttons[2].gameObject.SetActive(true);

        }
        
        else if (canvas is CanvasGamePlay)
        {     
            buttons[0].gameObject.SetActive(true);
            
            buttons[1].gameObject.SetActive(true);
            

        }

    }
    //0-1-2 : mainmenu-continue-close
    public void ContinueAndCloseButton()
    {
        Close(0);
        GameStateManager.Instance.ChangeState(GameState.gamePlay);
    }


    public void MainMenuButton()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasMainMenu>();
        GameStateManager.Instance.ChangeState(GameState.mainMenu);
    }
}
