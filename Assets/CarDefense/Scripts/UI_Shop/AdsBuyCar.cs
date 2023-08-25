using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;

[CreateAssetMenu(fileName = "AdsBuyCar",menuName = "ShopBuyCar/AdsBuyCar",order = 2)]
public class AdsBuyCar : ShopBuyCarsType
{
    [SerializeField] private RewardVideoAds rewardVideoAds;
    public override void BuyCar()
    {
        MyADS.Instance.CallAddAndExecuteFunctionAfterSucces(rewardVideoAds.ToString(), GiveRewardForAds);
    }
    
    private void GiveRewardForAds()
    {
        int adsWatch = ES3.Load(SaveKeys.BuyTruckWithAds + CarBuy.CarId,0);
        adsWatch++;
        if (adsWatch < Price)
        {
            ES3.Save(SaveKeys.BuyTruckWithAds + CarBuy.CarId,adsWatch);
        }
        else
        {
            GetReward();
        }

        DealerShopPanel.SetCurrentCar?.Invoke(this);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "WATCH_ADS_FOR_CAR_" + adsWatch);
    }

    public override void GetReward()
    {
        CarBuy.Owned = true;
        GlobalCarsContainer.SaveCurrentCar(CarBuy);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "GIVE_CAR_FOR_ADS");
    }
    
   
}
