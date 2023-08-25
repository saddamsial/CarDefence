using System.Collections;
using System.Collections.Generic;
//using GameAnalyticsSDK;
using UnityEngine;

[CreateAssetMenu(fileName = "IAP Item", menuName = "IAP/Coin Iap", order = 0)]
public class CoinsIapItem : IAPItem
{
   [SerializeField] private int rewardCount;

   public override void GetReward()
   {
       //Exemple
      
      //GameCurrencyManager.Coins += rewardCount;
     // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "PURCHASE_IAP_COINS_" + rewardCount);
   }
}
