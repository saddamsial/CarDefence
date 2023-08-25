using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;
[CreateAssetMenu(fileName = "FarmingCoinsBuyCar",menuName = "ShopBuyCar/FarmingCoinsBuyCar",order = 1)]
public class FarmingCoinsBuyCar : ShopBuyCarsType
{
    public override void BuyCar()
    {
        if (Price <= GameCurrencyManager.FarmingCoins)
        {
            GameCurrencyManager.FarmingCoins -= Price;
            GetReward();

        }
        else
        {
           // TopPanel.ShowInfoPopUp?.Invoke(GlobalTextsContainer.NoEnoughGems);
        }
        
    }

    public override void GetReward()
    {
        CarBuy.Owned = true;
        GlobalCarsContainer.SaveCurrentCar(CarBuy);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "BUY_TRUCK_WITH_GEMS" ,"CAR_ID" + CarBuy.CarId);
    }
}
