using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.Purchasing;

[CreateAssetMenu(fileName = "WinCoinsBuyCar",menuName = "ShopBuyCar/WinCoinsBuyCar",order = 0)]
public class WinCoinsBuyCar : ShopBuyCarsType
{
    public override void BuyCar()
    {
        if (Price <= GameCurrencyManager.WinCoins)
        {
            GameCurrencyManager.WinCoins -= Price;
            GetReward();

        }
        else
        {
          //TopPanel.ShowInfoPopUp?.Invoke(GlobalTextsContainer.NoEnoughCoins);
        }
        
    }

    public override void GetReward()
    {
        CarBuy.Owned = true;
        GlobalCarsContainer.SaveCurrentCar(CarBuy);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "BUY_TRUCK_WITH_COINS","TRUCK_ID_" + CarBuy.CarId);
    }
}
