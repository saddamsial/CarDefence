using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class IapButton : MonoBehaviour
{
    [SerializeField] protected IAPItem iapItem;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private TextMeshProUGUI rewardValue;
    [SerializeField] protected Button iapButton;

    private void Awake()
    {
        iapButton.onClick.AddListener(BuyIap);
        if (price)
        {
            price.text = iapItem.PriceText;
        }
        if (rewardValue)
        {
            rewardValue.text = iapItem.RewardText;
        }
    }

    protected virtual void BuyIap()
    {
        Debug.Log("IAP->ID " + iapItem.Identifier);

        IAPManager.instance.Buy(iapItem.Identifier);
    }
}