using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    private GameObject[] levelPrefabs;
    private GameObject currentLevel;
    private void Awake()
    {
        levelPrefabs = Resources.LoadAll<GameObject>(("Level/"));
    }
    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelPrefabs.Length)
        {
            return;
        }
        if (currentLevel != null)

        {
            Destroy(currentLevel);
        }

        currentLevel = Instantiate(levelPrefabs[levelIndex],this.transform);
    }

    public void RetryLevel()
    {
   
    }

}
