using System;
using UnityEditor.Search;

[System.Serializable]
public class CharacterModel
{
    public int id;

    public float currentDao;
    public float maxDao;
    public float incDao;
    public float multiplieIncDao;
    public int level;
    public Action onLevelUp;

    public CharacterModel(int id, float maxDao, float incDao, float multiplieIncDao)
    {
        this.id = id;
        this.currentDao = 0;
        this.maxDao = maxDao;
        this.level = 1;
        this.incDao = incDao;
        this.multiplieIncDao = multiplieIncDao;
    }

    public CharacterModel(CharacterAsset asset) : this(asset.id, asset.maxDao, asset.incDao, asset.miltiplieIncDao)
    {
    }

    public void AddXp(int xp)
    {
        currentDao += xp;
        if(currentDao >= maxDao)
        {
            LevelUp();
            currentDao = 0;
        }
    }

    public void LevelUp(int level = 1)
    {
        for (int i = 0; i < level; i++)
        {
            maxDao *= multiplieIncDao;
        }
        level++;
        onLevelUp?.Invoke();
    }
}
