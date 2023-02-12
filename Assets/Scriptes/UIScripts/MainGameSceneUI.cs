using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainGameSceneUI : MonoBehaviour
{
    // Скрипт Виузального типа. Для назначения визуальным элементам числовых значений персонажа на главной сцене.
    public LevelController levelController;

    [Header("UI элементы")]
    public TextMeshProUGUI levelUiText; // Текстовый элемент отображающий уровень персонажа
    public TextMeshProUGUI currentUiText; // Текстовый элемент отображающий текущее количество Дао
    public TextMeshProUGUI maxDaoUiText; // Текстовый элемент отображающий максимальное количество Дао, до прорыва
    public TextMeshProUGUI daoRangeText; // Текстовый элемент отображающий текущий ранг на пути Дао
    public Slider slider; // ползунок отображающий прогресс на пути Дао

    // Start is called before the first frame update
    void Start()
    {
        levelController.onCharacterUpdate += UpdateUI; // Здесь мы подписываемся на событие увеличения дао
        levelController.onCharacterAdd += UpdateUI; // Здесь мы подписываемся на событие увеличения ранга
        if (levelController.HasCharacter)
        {
            UpdateUI();
        }
    }

    /// <summary>
    /// Эта функция обновляет информацию для визуальных элементов игры.
    /// </summary>
    private void UpdateUI()
    {
        levelUiText.text = levelController.Level.ToString();
        currentUiText.text = levelController.CurrentDao.ToString();
        maxDaoUiText.text = levelController.MaxDao.ToString();
        daoRangeText.text = levelController.LevelRange;
        slider.value = levelController.CurrentDao / levelController.MaxDao;
    }
}
