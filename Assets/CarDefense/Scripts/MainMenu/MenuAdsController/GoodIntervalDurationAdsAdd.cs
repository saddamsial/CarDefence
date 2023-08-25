using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodIntervalDurationAdsAdd : AdsRewards
{
    private void Start()
    {
        currentCarId = GlobalCarsContainer.currentCar.CarId;
        adsButton.onClick.AddListener(WatchAdsForReward);
        currentAds = ES3.Load(SaveKeys.AdsReward + adsType + currentCarId, 0);
       
       UpdateUi();
    }

    public override void WatchAdsForReward()
    {
       MyADS.Instance.CallAddAndExecuteFunctionAfterSucces(adsType.ToString(),GetReward);
    }

    public override void GetReward()
    {
        //give reward and save;
        currentAds++;
        ES3.Save(SaveKeys.AdsReward + adsType + currentCarId, currentAds);
        if (currentAds >= adsPrice)
        {
            ES3.Save(SaveKeys.GoodIntervalDuration + currentCarId,ES3.Load(SaveKeys.GoodIntervalDuration + currentCarId,6)+1);
          
           
        }
        UpdateUi();
    }

    private void UpdateUi()
    {
        if (currentAds == 0)
        {
            adsCountText.text = "Increase Good Interval Duration";
        }
        else if(currentAds < 10)
        {
            adsCountText.text = $"{currentAds}/{adsPrice} ADS";
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
