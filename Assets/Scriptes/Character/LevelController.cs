using Assets.Scriptes.Save;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public CharacterAsset _asset;
    public ExpManager _manager;
    public SaveSystem _save;
    private CharacterModel _character;
    public Action onCharacterUpdate;

    public float CurrentDao => _character.currentDao;
    public float MaxDao => _character.maxDao;
    public int Level => _character.level;

    private void Awake()
    {
        if (_save.characterData != null)
            _character = _save.characterData;
        else
            _character = new CharacterModel(_asset);

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
