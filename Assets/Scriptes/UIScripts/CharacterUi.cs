using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUi : MonoBehaviour
{
    public LevelController levelController;

    [Header("UI элементы")]
    public TextMeshProUGUI levelUiText;
    public TextMeshProUGUI currentUiText;
    public TextMeshProUGUI maxDaoUiText;
    public TextMeshProUGUI daoRangeText;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        levelController.onCharacterUpdate += UpdateUI;
        levelController.onCharacterAdd += UpdateUI;
        if (levelController.HasCharacter)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        levelUiText.text = levelController.Level.ToString();
        currentUiText.text = levelController.CurrentDao.ToString();
        maxDaoUiText.text = levelController.MaxDao.ToString();
        daoRangeText.text = levelController.LevelRange;
        slider.value = levelController.CurrentDao / levelController.MaxDao;
    }
}
