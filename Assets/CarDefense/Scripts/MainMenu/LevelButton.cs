using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{

    [SerializeField] private Button levelButton;
    [SerializeField] private TextMeshProUGUI levelText;

    public void Initialize(LevelContainer level)
    {
        levelButton.onClick.AddListener(level.StartLevel);
        levelText.text = "Level " + level.LevelIndex;
    }
}
