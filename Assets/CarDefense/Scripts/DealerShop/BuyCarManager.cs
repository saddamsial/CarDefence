using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BuyCarManager : MonoBehaviour
{
    [SerializeField] private Button buyButton;
    //[SerializeField] private GameObject playButton;
    
    [SerializeField] private TextMeshProUGUI buyText;
    [SerializeField] private TextMeshProUGUI adsCountText;
   // [SerializeField] private TextMeshProUGUI iapOldPriceText;
    [FormerlySerializedAs("_dealerShipPanel")] [SerializeField] private DealerShopPanel dealerShopPanel;
    private ShopBuyCarsType carData;

    private void Awake()
    {
        DealerShopPanel.SetCurrentCar += SelectTruckBuyData;
    }

    private void SelectTruckBuyData(ShopBuyCarsType carData)
    {
        this.carData = carData;
        BuyButtonState();
        
    }

    private void BuyTruck()
    {
        carData.BuyCar();
        dealerShopPanel.UpdateTruckIcon(carData);
        BuyButtonState();

    }

    private void BuyButtonState()
    {
        if (carData.CarBuy.Owned)
        {
            buyButton.gameObject.SetActive(false);
         //   playButton.SetActive(true);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
           // playButton.SetActive(false);
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(BuyTruck);
            adsCountText.gameObject.SetActive(false);
           // iapOldPriceText.gameObject.SetActive(false);

            switch (carData.Type)
            {
                case BuyType.WinCoins:
                    buyText.text = GameCurrencyManager.PriceConvert(carData.Price) + " <sprite index=[2]>";
                    break;
                case BuyType.FarmingCoins:
                    buyText.text = GameCurrencyManager.PriceConvert(carData.Price)  + " <sprite index=[0]>";
                    break;
                case BuyType.Ads:
                    adsCountText.gameObject.SetActive(true);
                    int adsWatchCount = ES3.Load(SaveKeys.BuyTruckWithAds + carData.CarBuy.CarId,
                        0);
                    adsCountText.text = adsWatchCount + $"/{carData.Price}";
                    buyText.text = "GET FREE";
                    break;
                case BuyType.Iap:
                  //  iapOldPriceText.gameObject.SetActive(true);
                  //  iapOldPriceText.text = carData.OldPrice + " $";
                    buyText.text = carData.Price  + " $";
                    break;
                    
            }
            
        }
     
        
    }

   
    private void OnDestroy()
    {
        DealerShopPanel.SetCurrentCar -= SelectTruckBuyData;
    }
}