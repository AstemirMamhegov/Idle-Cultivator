using System;
using UnityEditor.Search;

[Serializable]
public class CharacterModel : IPassiveDao, IPassiveELement
{
    #region �������������� ���������

    /// <summary>
    /// ���������� �������������
    /// </summary>
    public int id;

    /// <summary>
    /// ������ ������� �������� �������������� "���"
    /// </summary>
    public float currentDao;

    /// <summary>
    /// �������������� ���������� �������� ���� �� ����������.
    /// </summary>
    public int damageCharacter;

    /// <summary>
    /// ���������� ����������� ��������� ����������, ����� ��� ���������� �������������� "���"
    /// </summary>
    public float maxDao;

    /// <summary>
    /// �������� ����������� "���" ���������
    /// </summary>
    public int passiveDao;

    /// <summary>
    /// ������ ������ ������ ���������
    /// </summary>
    public string levelRange;

    /// <summary>
    /// ���������� �������� �������� � ������� �� ���� ���������� ���. ������ � ��������������� levelRange
    /// </summary>
    public int level;

    #endregion

    /// <summary>
    /// ��������� ������ �������� ����� ���������
    /// </summary>
    [NonSerialized] private CharacterUpgrade characterUpgrade;

    /// <summary>
    /// ������� ������� ������������� ��� ���������� ������ ���������
    /// </summary>
    public Action onLevelUp;

    public int Dao => passiveDao;

    /// <summary>
    /// ����������� ������ CharacterModel
    /// </summary>
    /// <param name="id"></param>
    /// <param name="level"></param>
    public CharacterModel(int id, int level)
    {
        this.id = id;
        this.currentDao = 0;
        this.level = level;
        this.passiveDao = 1;
    }

    /// <summary>
    /// ����������� ������ CharacterModel ��� ������ ScriptableObject
    /// </summary>
    /// <param name="asset"></param>
    public CharacterModel(CharacterAsset asset) : this(asset.id, asset.level)
    {
    }

    /// <summary>
    /// ������� ��� ������������ ����� ��������� ������ ������������ ������
    /// </summary>
    /// <param name="upgrade"></param>
    public void SetUpgradeRange(CharacterUpgrade upgrade)
    {
        characterUpgrade = upgrade;
        SetLevel(level);
    }

    /// <summary>
    /// ������� ������������ ���������� ���������� ����� ��������� ��� ���������� ������
    /// </summary>
    /// <param name="level"></param>
    public void SetLevel(int level)
    {
        maxDao = characterUpgrade.levelDaos[level].maxDao;
        levelRange = characterUpgrade.levelDaos[level].nameOfRange;
    }


    /// <summary>
    /// ������� ���������� ��� ����� ����� ����.
    /// </summary>
    /// <param name="dao"></param>
    public void AddDao(int dao)
    {
        currentDao += dao;

        // ���� ������� ��� �������� ��� ������ ����� ������������� - ���������� ������� ��������� ����� ������ ������� LevelUp
        if (currentDao >= maxDao)
        {
            if (level < characterUpgrade.MaxLevel)
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

    /// <summary>
    /// ������� ������������� ������� �� ������� � ��������� ���� ���������
    /// </summary>
    public void LevelUp()
    {
        level++;
        SetLevel(level);

        onLevelUp?.Invoke();
    }

    /// <summary>
    /// ������� ��� ���������� �������� ������������� ���������� ���
    /// </summary>
    /// <returns></returns>
    public int GetDao()
    {
        return Dao;
    }

}
