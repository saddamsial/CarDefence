using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{

    [SerializeField] private PlayerCarForce playerCarForce;
    [SerializeField] private BotController botController;
   
    [SerializeField] private List<Transform> spawnPositions;
    [SerializeField] private List<FinishTrigers> finishTrigerses;
    [SerializeField] private SkillsManagerGamePlay _skillsManagerGamePlay;
    [SerializeField] private PlayersHealManager _playersHealManager;
    [SerializeField] private IntroRaceManager _introRaceManager;
     private GameObject playerCar;
     private GameObject botCar;

     private CarComponents _carComponents;
    

    public void CareerSpawnCar()
    {
        playerCar = Instantiate(Resources.Load<GameObject>(GlobalCarsContainer.currentCar.Location),spawnPositions[0]);
        botCar = Instantiate(Resources.Load<GameObject>(GlobalCareerContainer.currentLevel.BotPlayer.BotCarLocation),spawnPositions[1]);
        playerCar.GetComponent<RCC_PhotonNetwork>().enabled = false;
        botCar.GetComponent<RCC_PhotonNetwork>().enabled = false;
      
        botController.InitializeBotStats(botCar.GetComponent<RCC_CarControllerV3>());
      
       finishTrigerses[0].isPlayerFinish = true;
        SetPlayerInitialize();
        

    }

    public void OnlineSpawnCar()
    {
        botController.enabled = false;
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            playerCar = PhotonNetwork.Instantiate(Path.Combine(GlobalCarsContainer.currentCar.Location), spawnPositions[0].position,spawnPositions[0].rotation);
            finishTrigerses[0].isPlayerFinish = true;
            // playerCarForce.Initialize(playerCar.GetComponent<RCC_CarControllerV3>());
        }
        else
        {
            playerCar = PhotonNetwork.Instantiate(Path.Combine(GlobalCarsContainer.currentCar.Location), spawnPositions[1].position,spawnPositions[1].rotation);
            finishTrigerses[1].isPlayerFinish = true;
        }

        SetPlayerInitialize();
    }

    private void SetPlayerInitialize()
    {
        _carComponents = playerCar.GetComponent<CarComponents>();
       
        playerCarForce.InitializeStats(_carComponents);
        _skillsManagerGamePlay.Initialize(_carComponents);
        _carComponents.CarHealBar.Initialize(_carComponents.carData.SaveStats.carBaseHealPoints);
        _carComponents.CarHealBar.SetCarHealBar(_playersHealManager.playerHealBar);
        
         _introRaceManager.Initialize(playerCar.transform);
        
       
         
         
         
         
    }
    
   
}
