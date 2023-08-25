using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "IapScoreCoefficienItem",menuName = "IAP/Iap Score Coefficient Item")]
public class IapScoreCoefficientItem : IAPItem
{
    
    
    [SerializeField] private int iapLevelUpgrade;
    public override void GetReward()
    {
        //Exemple
      
        //GameCurrencyManager.Coins += rewardCount;
        // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "PURCHASE_IAP_COINS_" + rewardCount);
        ES3.Save(SaveKeys.IapScoreAddСoefficient,ES3.Load(SaveKeys.IapScoreAddСoefficient,0) +1);
        ES3.Save(SaveKeys.IapScoreCoefficientLevelUpgrade + iapLevelUpgrade, true);
        PanelsManagerUI.OpenPanel?.Invoke(PanelType.IapPanel,false);
    }

    public override bool CheckBuyStat()
    {

        if (ES3.Load(SaveKeys.IapScoreCoefficientLevelUpgrade + iapLevelUpgrade,false))
        {
            return true;
        }
        return false;
    }
}
