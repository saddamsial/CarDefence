//using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.Purchasing;


[CreateAssetMenu(fileName = "IAP Item", menuName = "IAP/IAP Item", order = 0)]
public class IAPItem : ScriptableObject
{
    [SerializeField] private ProductType productType;
    [SerializeField] private string productId;
    [SerializeField] private ProductIdentifier productIdentifier;
    [SerializeField] protected string rewardText;
    [SerializeField] protected string priceText;
    public ProductType TypeProduct => productType;

    public string ProductId => productId;

    public ProductIdentifier Identifier => productIdentifier;

    public string PriceText => priceText;

    public string RewardText => rewardText;

    public virtual void GetReward()
    {
    }
    public virtual bool CheckBuyStat()
    {
        return false;
    }
}