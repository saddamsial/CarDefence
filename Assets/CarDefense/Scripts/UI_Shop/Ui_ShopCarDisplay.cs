using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui_ShopCarDisplay : MonoBehaviour
{
    public ShopBuyCarsType myData;
    [SerializeField] private Button displayButton;

    [Header("InGameObjects")] 
    public TextMeshProUGUI displayText;
    public Image displayImage;
    public RectTransform selectImageParent;
    
    public void SetupObject(ShopBuyCarsType data)
    {
        myData = data;
        SetupMe();
        displayButton.onClick.AddListener(SpawnThisCar);  
    }

    private void SetupMe()
    {
        displayImage.sprite = myData.TruckSprite;
        UpdateTextInfo();

    }

    public void UpdateTextInfo()
    {
        if (myData.CarBuy.Owned)
        {
            displayText.text = "Owned";
        }
        else
        {
            switch (myData.Type)
            {
                case BuyType.WinCoins :
                    displayText.text = myData.Price  + " <sprite index=[2]>";
                    break;
                case BuyType.FarmingCoins:
                    displayText.text = myData.Price  + " <sprite index=[0]>";
                    break;
                case BuyType.Ads:
                    displayText.text = "GET FREE";
                    break;
                case BuyType.Iap:
                    displayText.text = myData.Price + " $";
                    break;

            }
           
        }
       
    }
    

    public void  SpawnThisCar()
    {
        DealerShopPanel.SetCurrentCar?.Invoke(myData);
    }
}