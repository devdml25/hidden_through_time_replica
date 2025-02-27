using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/Level Data", order = 1)]
public class LevelData : ScriptableObject
{
    public List<MyLevelData> data;
}

[System.Serializable]
public class MyLevelData
{
    public string LevelName;
    public int scoreToWin;
    public GameObject LevelPrefab;
    public List<GameObject> item;
    public List <Transform> itemSpwanPoint;
    public List<GameObject> itemMenu;
}
