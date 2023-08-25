using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using GameAnalyticsSDK.Setup;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DealerShopPanel : PanelConfiguration
{
    public static Action<ShopBuyCarsType> SetCurrentCar;
    [SerializeField] private GameObject carButton;
    [SerializeField] private Transform content;
    // [SerializeField] private RectTransform selectImage;
    // [SerializeField] private ScrollRect scroll; 
    [SerializeField] private List<Ui_ShopCarDisplay> carsButtonsList;
    private List<ShopBuyCarsType> _shopCarsList;

    private int currentTruckIndex;

    public override void Show()
    {
        gameObject.SetActive(true);
        Initialize();
      //  scroll.DOHorizontalNormalizedPos(0, 0.1f);
        GarageSpawnCar.SpawnCar(_shopCarsList[0].CarBuy);

    }

    private void Initialize()
    {
        foreach (var truckData in _shopCarsList)
        {
            Ui_ShopCarDisplay truckIcon = Instantiate(carButton, content).GetComponent<Ui_ShopCarDisplay>();
            truckIcon.SetupObject(truckData);
            carsButtonsList.Add(truckIcon);
           
        }
        carsButtonsList[0].SpawnThisCar();
       // carsButtonsList.Find(e=>e.myData.CarBuy.CarId == GlobalCarsContainer.currentCar.CarId).SpawnThisCar();
        
    }

    public void UpdateTruckIcon(ShopBuyCarsType shopCarData)
    {
        carsButtonsList.Find(e=>e.myData == shopCarData).UpdateTextInfo();
    }
    

    private void SpawnCar(ShopBuyCarsType carData)
    {
        GarageSpawnCar.SpawnCar?.Invoke(carData.CarBuy);
    }

  
    public override void Hide()
    {
        gameObject.SetActive(false);
        RemoveTrucksButtons();
    }

    private void RemoveTrucksButtons()
    {
       // selectImage.SetParent(transform);
        for (var i = 0; i < carsButtonsList.Count; i++)
        {
            Destroy(carsButtonsList[i].gameObject);
        }

        carsButtonsList.Clear();
    }

    public override void ActivateListeners()
    {
        SetCurrentCar += SpawnCar;
        _shopCarsList = Resources.LoadAll<ShopBuyCarsType>(PathLocation.ShopCardLocation).ToList();
        _shopCarsList = _shopCarsList.OrderBy(e => e.ShopOrder).ToList();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentTruckIndex++;
            if (currentTruckIndex >= _shopCarsList.Count)
            {
                currentTruckIndex = 0;
            }
            GarageSpawnCar.SpawnCar?.Invoke(_shopCarsList[currentTruckIndex].CarBuy);
        }
    }

    private void OnDestroy()
    {
        SetCurrentCar -= SpawnCar;
    }
}