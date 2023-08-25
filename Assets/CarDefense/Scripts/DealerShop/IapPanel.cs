using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IapPanel : PanelConfiguration
{
    [SerializeField] private GameObject getFreeButton;
    [SerializeField] private GameObject noAdsButton;
    [SerializeField] private Button restorePurchaseButton;
    public override void Show()
    {
        gameObject.SetActive(true);
        getFreeButton.SetActive(false);
        // if (ES3.Load(SaveKey.BuyNoAds, false) == false)
        // {
        //     noAdsButton.SetActive(true);
        // }
    }
    public override void Hide()
    {
        gameObject.SetActive(false);
        getFreeButton.SetActive(true);
    }

    public override void ActivateListeners()
    {
      //  restorePurchaseButton.onClick.AddListener(IAPManager.instance.RestorePurchases);
    }
}
