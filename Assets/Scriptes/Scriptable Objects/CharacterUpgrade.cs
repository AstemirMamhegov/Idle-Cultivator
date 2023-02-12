using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterUpgrade", menuName = "Custom/CharacterUpgrade", order = 0)]
public class CharacterUpgrade : ScriptableObject
{
    public LevelDao[] levelDaos;
    public int MaxLevel => levelDaos.Length - 1;
}

[Serializable]
public class LevelDao
{
    public string nameOfRange;
    public float maxDao;
}
