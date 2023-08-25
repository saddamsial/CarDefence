using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MainMenuSpawnCar : MonoBehaviour
{
    [SerializeField] private RCC_CarControllerV3 playerControllerV3;
    [SerializeField] private CinemachineVirtualCamera camMove;
    [SerializeField] private UpgradePanel upgradePanel;
    
    private GameObject playerCar;
    private bool isStart;
    private float sensitivity
    {
        get { return RCC_Settings.Instance.UIButtonSensitivity; }
    }
    void Start()
    {
        SpawnCar();
    }


    private void SpawnCar()
    {
        playerCar = Instantiate(Resources.Load<GameObject>(GlobalCarsContainer.currentCar.Location),transform);
        playerCar.GetComponent<RCC_PhotonNetwork>().enabled = false;
        playerControllerV3 = playerCar.GetComponent<RCC_CarControllerV3>();
        
        playerControllerV3.maxEngineTorque = 1500;
        playerControllerV3.PreviewSmokeParticle(true);
        playerControllerV3.rigid.freezeRotation = true;
        
        
        camMove.Follow = playerCar.transform;
        camMove.LookAt = playerCar.transform;
        isStart = true;
        
        CarComponents carComponents =    playerCar.GetComponent<CarComponents>();
        carComponents.carData.Initialize();
        carComponents.carGunsHolder.InitializeGunsInMenu(carComponents.carData.SaveStats.activeSkills);
      
        
       
        
        upgradePanel.Initialize(carComponents);
        
    }
    
}
