using System.Collections;
using System.Collections.Generic;
//using GameAnalyticsSDK;
using UnityEngine;

[CreateAssetMenu(fileName = "IAP Item", menuName = "IAP/NoAds Iap", order = 0)]

public class NoAdsIapItem : IAPItem
{
    public override void GetReward()
    {
        //Exemple
      //  ES3.Save(SaveKey.BuyNoAds,true);
      //  GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "PURCHASE_IAP_NoAds");
    }
}
