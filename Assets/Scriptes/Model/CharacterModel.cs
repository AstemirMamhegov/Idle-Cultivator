using System;
using UnityEditor.Search;

[Serializable]
public class CharacterModel : IPassiveDao, IPassiveELement
{
    #region Характеристики Персонажа

    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public int id;

    /// <summary>
    /// Хранит текущий прогресс характеристики "Дао"
    /// </summary>
    public float currentDao;

    /// <summary>
    /// Характеристика передающая итоговый урон по противнику.
    /// </summary>
    public int damageCharacter;

    /// <summary>
    /// Обозначает максимально возможное количество, нужно для накопления характеристики "Дао"
    /// </summary>
    public float maxDao;

    /// <summary>
    /// Пассивно увеличивает "Дао" персонажа
    /// </summary>
    public int passiveDao;

    /// <summary>
    /// хранит список рангов персонажа
    /// </summary>
    public string levelRange;

    /// <summary>
    /// отображает числовой прогресс в уровнях на пути постижения дао. Связан с характеристикой levelRange
    /// </summary>
    public int level;

    #endregion

    /// <summary>
    /// Экземпляр класса хранящий ранги персонажа
    /// </summary>
    [NonSerialized] private CharacterUpgrade characterUpgrade;

    /// <summary>
    /// Событие которое подписывается для увеличения уровня персонажа
    /// </summary>
    public Action onLevelUp;

    public int Dao => passiveDao;

    /// <summary>
    /// Конструктор класса CharacterModel
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
    /// Конструктор класса CharacterModel для класса ScriptableObject
    /// </summary>
    /// <param name="asset"></param>
    public CharacterModel(CharacterAsset asset) : this(asset.id, asset.level)
    {
    }

    /// <summary>
    /// Функция для присваивания ранга персонажу равное достигнутому уровню
    /// </summary>
    /// <param name="upgrade"></param>
    public void SetUpgradeRange(CharacterUpgrade upgrade)
    {
        characterUpgrade = upgrade;
        SetLevel(level);
    }

    /// <summary>
    /// Функция привязывания конкретных переменных ранга персонажа при увеличении уровня
    /// </summary>
    /// <param name="level"></param>
    public void SetLevel(int level)
    {
        maxDao = characterUpgrade.levelDaos[level].maxDao;
        levelRange = characterUpgrade.levelDaos[level].nameOfRange;
    }


    /// <summary>
    /// Функция добавление Дао путем клика мыши.
    /// </summary>
    /// <param name="dao"></param>
    public void AddDao(int dao)
    {
        currentDao += dao;

        // Если текущее дао превысит или станет равно максимальному - повыситься уровень персонажа путем вызова функции LevelUp
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
    /// Функция увеличивающая уровень на единицу и сменяющая ранг персонажа
    /// </summary>
    public void LevelUp()
    {
        level++;
        SetLevel(level);

        onLevelUp?.Invoke();
    }

    /// <summary>
    /// Функция для увеличения числовой харатеристики пассивного дао
    /// </summary>
    /// <returns></returns>
    public int GetDao()
    {
        return Dao;
    }

}
