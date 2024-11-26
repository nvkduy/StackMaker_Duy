using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Player player;
    public Action<Transform> PlayerTF;
    public List<Level> levelPrefab;
    private Level currentLevel;
  
    private int levelIndex;

    public int LevelIndex => levelIndex;
  
    private void Start()
    {
        levelIndex = PlayerPrefs.GetInt("Level", 0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }

    public void OnInit()
    {

        Transform spawnPoint = currentLevel.spawnPoint;
        

        SpawnPlayer(spawnPoint);
    }

    private void SpawnPlayer(Transform spawnPoint)
    {
        GameObject playerObject = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        player = playerObject.GetComponent<Player>();
        PlayerTF?.Invoke(player.transform);
    }
    public void OnFinshGame()
    {
        OnReset();
        Destroy(currentLevel.gameObject);
    }

    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        if (level < levelPrefab.Count)
        {
            PlayerPrefs.SetInt("Level", level);
            currentLevel = Instantiate(levelPrefab[level]);
            if (currentLevel == null)
            {
                Debug.LogError("Failed to instantiate the level.");
            }
        }
        else
        {
            Debug.LogError("Level index out of range.");
        }
    }

    public void OnReset()
    {

        Destroy(player.gameObject);
        Destroy(currentLevel.gameObject);
    }

    internal void NextLevel()
    {
        levelIndex = (levelIndex + 1) % levelPrefab.Count;
        PlayerPrefs.SetInt("Level", levelIndex);
        OnReset();
        LoadLevel(levelIndex);
        OnInit();
    }

  
    internal void RetryLevel()
    {
        OnReset();
        LoadLevel(levelIndex);
        OnInit();
    }
}



