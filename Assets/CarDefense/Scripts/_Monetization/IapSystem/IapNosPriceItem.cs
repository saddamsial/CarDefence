using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "IapNosPriceItem",menuName = "IAP/Iap Nos Price Item")]
public class IapNosPriceItem : IAPItem
{
    [SerializeField] private int iapLevelUpgrade;
    public override void GetReward()
    {
        //Exemple
      
        //GameCurrencyManager.Coins += rewardCount;
        // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "PURCHASE_IAP_COINS_" + rewardCount);
        ES3.Save(SaveKeys.IapNosPrices,ES3.Load(SaveKeys.IapNosPrices,0)-100);
        ES3.Save(SaveKeys.IapNosPriceLevelUpgrade + iapLevelUpgrade, true);
        PanelsManagerUI.OpenPanel?.Invoke(PanelType.IapPanel,false);
    }

    public override bool CheckBuyStat()
    {

        if (ES3.Load(SaveKeys.IapNosPriceLevelUpgrade + iapLevelUpgrade,false))
        {
            return true;
        }
        return false;
    }
}
