using System.Collections;
using System.Collections.Generic;
//using GameAnalyticsSDK;
using UnityEngine;


[CreateAssetMenu(fileName = "IAP Item", menuName = "IAP/Gem Iap", order = 0)]
public class GemsIapItem : IAPItem
{
    [SerializeField] private int rewardCount;

    public override void GetReward()
    {
     
        
        //Exemple
        //GameCurrencyManager.Gems += rewardCount;
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "PURCHASE_IAP_GEMS_" + rewardCount);
    }
}
