using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelData levelData;
    public int currentLevelIndex;
    public Transform prefabsSpawn;
    private GameObject currentLevelInstance;

    void Start()
    {
        
        LoadLevel(currentLevelIndex);
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelData.data.Count) return;

        DeleteCurrentLevl();
     
        MyLevelData levelInfor = levelData.data[levelIndex];

        if (levelInfor == null) return;

        currentLevelInstance = Instantiate(levelInfor.LevelPrefab, prefabsSpawn);

        currentLevelIndex = levelIndex;

    }

    public void DeleteCurrentLevl()
    {
        if (currentLevelInstance == null) return;
        Destroy(currentLevelInstance);
        currentLevelInstance = null;

    }
}
