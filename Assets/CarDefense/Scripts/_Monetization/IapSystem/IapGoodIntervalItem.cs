using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IapGoodIntervalItem",menuName = "IAP/Iap Good Interval Item")]
public class IapGoodIntervalItem : IAPItem
{
    
    [SerializeField] private int iapLevelUpgrade;
    public override void GetReward()
    {
        //Exemple
      
        //GameCurrencyManager.Coins += rewardCount;
        // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "PURCHASE_IAP_COINS_" + rewardCount);
        ES3.Save(SaveKeys.IapGoodIntervalDuration,ES3.Load(SaveKeys.IapGoodIntervalDuration,0)+1);
        ES3.Save(SaveKeys.IapGoodIntervalLevelUpgrade + iapLevelUpgrade, true);
        PanelsManagerUI.OpenPanel?.Invoke(PanelType.IapPanel,false);
    }

    public override bool CheckBuyStat()
    {

        if (ES3.Load(SaveKeys.IapGoodIntervalLevelUpgrade + iapLevelUpgrade,false))
        {
            return true;
        }
        return false;
    }
}
