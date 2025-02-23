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

        SpawnItems(levelInfor);

    }

    public void DeleteCurrentLevl()
    {
        if (currentLevelInstance == null) return;
        Destroy(currentLevelInstance);
        currentLevelInstance = null;

    }

    public void SpawnItems(MyLevelData levelInfo)
    {
        if (levelInfo.item == null || levelInfo.item.Count == 0 || levelInfo.itemSpwanPoint == null || levelInfo.itemSpwanPoint.Count == 0) return;

        for (int i = 0; i < levelInfo.itemSpwanPoint.Count; i++)
        {
            if (i > levelInfo.itemSpwanPoint.Count) return;
            GameObject item = levelInfo.item[i];
            Transform spawnPoint = levelInfo.itemSpwanPoint[i];

            if (spawnPoint == null && item == null) return;
            Instantiate(item, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
