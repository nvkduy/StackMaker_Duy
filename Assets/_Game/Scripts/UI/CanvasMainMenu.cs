using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : UICanvas
{
    public void PlayButton()
    {
        Close(0);
        //Instance key để truy cập tới đối tượng duy nhất của lớp UIManager mà không cần phải tạo mới mỗi lần muốn sử dụng.
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        GameStateManager.Instance.ChangeState(GameState.gamePlay);
    }

    public void SettingsButton()
    {
        GameStateManager.Instance.ChangeState(GameState.settings);
        UIManager.Instance.OpenUI<CanvasSettings>().SetState(this);
    }
}