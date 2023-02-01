using Assets.Scriptes.Save;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LevelController : MonoBehaviour
{
    public CharacterAsset _asset;
    public CharacterUpgrade _assetUpgrade;
    public ExpManager _manager;
    public SaveSystem _save;
    private CharacterModel _character;
    public Action onCharacterUpdate;
    public Action onCharacterAdd;

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

        _character.SetUpgrade(_assetUpgrade);
        onCharacterAdd?.Invoke();

        _save.characterData = _character;
        _manager.onMouseDown += AddXp;
    }

    private void AddXp(int xp)
    {
        _character.AddXp(xp);
        onCharacterUpdate?.Invoke();
        _save.Save();
    }
}
