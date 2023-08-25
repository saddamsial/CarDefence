using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelContainer",menuName = "Career/LevelContainer",order = 0)]

public class LevelContainer : ScriptableObject
{
   [SerializeField] private int levelIndex;
   [SerializeField] private BotPlayerData botPlayerData;
   [SerializeField] private string sceneName;
   [SerializeField] private int maxSpeed;

   [SerializeField] private CarSaveStats botCarStats;
   

   public int LevelIndex => levelIndex;

   public BotPlayerData BotPlayer => botPlayerData;
   

   public int MaxSpeed => maxSpeed;
   
   public CarSaveStats BotCarStats => botCarStats;


   public void StartLevel()
   {
      GlobalCareerContainer.currentLevel = this;
      ES3.Save(SaveKeys.GameMode,GameModeType.CareerMode);
      SceneManager.LoadScene(sceneName);
   }
}
