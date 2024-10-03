using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasVictory>().SetBestScore(score);
        }
    }
}
