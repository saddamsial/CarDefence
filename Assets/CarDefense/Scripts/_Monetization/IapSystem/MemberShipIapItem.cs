using System.Collections;
using System.Collections.Generic;
//sing GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "IAP Item", menuName = "IAP/MemberShip Iap", order = 0)]
public class MemberShipIapItem : IAPItem
{
   [SerializeField] private int coinsReward;
   [SerializeField] private int gemsReward;
 //  [SerializeField] private TruckData truckForSubscription;
   public override void GetReward()
   {
      
      //Exemple 
      // ES3.Save(SaveKey.BuyMemberShip,true);
      // //No ads
      // ES3.Save(SaveKey.BuyNoAds,true);
      //
      // //Money
      // GameCurrencyManager.Coins += coinsReward;
      //
      // //Gem 
      // GameCurrencyManager.Gems += gemsReward;
      //
      // //X2 rewards
      // ES3.Save(SaveKey.DoubleRewards,true);
      //
      // //give Truck
      // truckForSubscription.Owned = true;
      //
      // GlobalTrucksManger.SaveCurrentTruck(truckForSubscription);
      // SceneManager.LoadScene("1_MainMenu");
      // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "PURCHASE_IAP_MEMBERSHIP");
   }
}
