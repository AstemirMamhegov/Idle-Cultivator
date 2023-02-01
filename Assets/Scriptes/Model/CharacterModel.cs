using System;
using UnityEditor.Search;

[Serializable]
public class CharacterModel
{
    public int id;

    public float currentDao;
    public float maxDao;
    public float multiplieIncDao;

    public string levelRange;
    public int level;

    [NonSerialized]private CharacterUpgrade characterUpgrade;

    public Action onLevelUp;

    public CharacterModel(int id, int level)
    {
        this.id = id;
        this.currentDao = 0;
        this.level = level;
    }

    public CharacterModel(CharacterAsset asset) : this(asset.id, asset.level)
    {
    }

    public void SetUpgrade(CharacterUpgrade upgrade)
    {
        characterUpgrade = upgrade;
        SetLevel(level);
    }

    public void SetLevel(int level)
    {
        maxDao = characterUpgrade.levelDaos[level].maxDao;
        levelRange = characterUpgrade.levelDaos[level].nameOfRange;
    }

    public void AddXp(int xp)
    {
        currentDao += xp;

        if (currentDao >= maxDao)
        {
            if(level < characterUpgrade.MaxLevel)
            {
                LevelUp();
                currentDao = 0;
            }
            else
            {
                currentDao = maxDao;
            }
        }
    }

    public void LevelUp()
    {
        level++;
        SetLevel(level);

        onLevelUp?.Invoke();
    }
}
