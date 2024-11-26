using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasGamePlay : UICanvas
{
    [SerializeField] TextMeshProUGUI coinText;

    public override void Setup()
    {
        base.Setup();
        UpdateCoin(0);
    }
    public void UpdateCoin(int coin)
    {
        coinText.text = coin.ToString();
    }
    public void SettingsButton()
    {
        UICanvas.Instance.Close(0);
        UIManager.Instance.OpenUI<CanvasSettings>().SetState(this);
        GameStateManager.Instance.ChangeState(GameState.settings);
    }

}