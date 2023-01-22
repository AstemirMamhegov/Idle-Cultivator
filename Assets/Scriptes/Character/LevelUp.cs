using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    [Header("UI элементы")]
    public TextMeshProUGUI levelUiText;
    public TextMeshProUGUI currentUiText;
    public TextMeshProUGUI targetUiText;
    public Slider slider;

    [Header("Числовые переменные")]
    public float levelUi;
    public float currentUi;
    float targetUi = 100;
    float targetDividend = 3;

    public static LevelUp instance;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        currentUiText.text = currentUi.ToString();
        targetUiText.text = targetUi.ToString();
        levelUiText.text = levelUi.ToString();

        slider.value = currentUi;
        slider.maxValue = targetUi;
    }

    public void AddXp(int xp)
    {
        currentUi += xp;
        slider.value += xp;

        while (currentUi >= targetUi)
        {
            LevelUpFunc();

        }

        currentUiText.text = currentUi.ToString();
    }

    public void LevelUpFunc() 
    {
        currentUi = currentUi - targetUi;
        slider.value = slider.value - targetUi;

        levelUi++;

        targetUi = targetUi * targetDividend;
        slider.maxValue = targetUi;

        levelUiText.text = levelUi.ToString();
        targetUiText.text = targetUi.ToString();
    }
}
