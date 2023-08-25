using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeCarType upgradeType;
    [SerializeField] private int upgradePrice;
    [SerializeField] private int upgradeAddBonus;
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private UILineRenderer lineRenderer;
    [SerializeField] private RectTransform pointOnCar;
    [SerializeField] private Button upgradeButton;

    private Transform carPointUpgrade;
    private int levelUpgrade;

    private int currentTypeValue;
    
    
    public void Initialize(Transform carPoint)
    {
        carPointUpgrade = carPoint;
    }

    public void ActivateListener()
    {
        upgradeButton.onClick.AddListener(UpgradeCarStats);
    }
    private void Update()
    {
        var screenPoint = mainCamera.WorldToScreenPoint(carPointUpgrade.position); 
        pointOnCar.position = screenPoint;
        lineRenderer.Points = new Vector2[] {Vector2.zero, pointOnCar.localPosition};

    }

    private void UpgradeCarStats()
    {
        levelUpgrade = ES3.Load(SaveKeys.LevelUpgrade + GlobalCarsContainer.currentCar.CarId, 1);
        upgradePrice = upgradePrice * levelUpgrade;

        if (GameCurrencyManager.FarmingCoins >= upgradePrice)
        {
            currentTypeValue = DefaultTypeValue();
            currentTypeValue += upgradeAddBonus;

            SetUpgrade(currentTypeValue);
            
            GameCurrencyManager.FarmingCoins -= upgradePrice;
            
        }
        else
        {
            //TODO Pop-up manager not enoughMoney;
        }
    }

    private int DefaultTypeValue()
    {

        switch (upgradeType)
        { 
            case UpgradeCarType.Mass:
                return GlobalCarsContainer.currentCar.SaveStats.carBaseMass;
            case UpgradeCarType.Torque:
                return GlobalCarsContainer.currentCar.SaveStats.carBaseTorque;
            
        }

        return 0;
    }

    private void SetUpgrade(int upgradeValue)
    {
        switch (upgradeType)
        { 
            case UpgradeCarType.Mass:
                 GlobalCarsContainer.currentCar.SaveStats.carBaseMass = upgradeValue;
                 GlobalCarsContainer.currentCar.CarSaveStats();
                break;
            case UpgradeCarType.Torque:
                 GlobalCarsContainer.currentCar.SaveStats.carBaseTorque = upgradeValue;
                 GlobalCarsContainer.currentCar.CarSaveStats();
                break;
        }
    }
}
