using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IapNosChargesItem",menuName = "IAP/Iap Nos Charges Item")]
public class IapNosChargesItem : IAPItem
{
    [SerializeField] private int iapLevelUpgrade;
    public override void GetReward()
    {
        //Exemple
      
        //GameCurrencyManager.Coins += rewardCount;
        // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "PURCHASE_IAP_COINS_" + rewardCount);
        ES3.Save(SaveKeys.IapNosCharges,ES3.Load(SaveKeys.IapNosCharges,0)+1);
        ES3.Save(SaveKeys.IapNosChargesLevelUpgrade + iapLevelUpgrade, true);
        PanelsManagerUI.OpenPanel?.Invoke(PanelType.IapPanel,false);
    }

    public override bool CheckBuyStat()
    {

        if (ES3.Load(SaveKeys.IapNosChargesLevelUpgrade + iapLevelUpgrade,false))
        {
            return true;
        }
        return false;
    }
}
