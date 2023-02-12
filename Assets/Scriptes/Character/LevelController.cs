using Assets.Scriptes.Save;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LevelController : MonoBehaviour
{
    // Экземпляры классов
    private CharacterModel _character;

    public CharacterAsset _asset;
    public CharacterUpgrade _assetUpgrade;

    public DaoManager _manager;
    public PassiveDao _passiveDao;
    public SaveSystem _save;

    // События
    public Action onCharacterUpdate;
    public Action onCharacterAdd;

    //Переназначение переменных класса Персонаж
    public float CurrentDao => _character.currentDao;
    public float MaxDao => _character.maxDao;
    public int Level => _character.level;
    public string LevelRange => _character.levelRange;
    public bool HasCharacter => _character != null;

    private void Start()
    {
        if (_save.characterData != null)
            _character = _save.characterData;
        else
            _character = new CharacterModel(_asset);

        _character.SetUpgradeRange(_assetUpgrade);
        onCharacterAdd?.Invoke();

        _save.characterData = _character;

        _passiveDao.AddPassiveElement(_character);
        _passiveDao.onDaoUpdate += AddDao;
        _manager.onMouseDown += AddDao;
    }

    /// <summary>
    /// Вызывает функцию добавления Дао и сохраняет прогресс в dat файл
    /// </summary>
    /// <param name="dao"></param>
    private void AddDao(int dao)
    {
        _character.AddDao(dao);
        onCharacterUpdate?.Invoke();
        _save.Save();
    }
}
