using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCoefficientAdsAdd : AdsRewards
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
        currentAds++;
        ES3.Save(SaveKeys.AdsReward + adsType + currentCarId, currentAds);
        if (currentAds >= adsPrice)
        {
            ES3.Save(SaveKeys.ScoreAddСoefficient + currentCarId,ES3.Load(SaveKeys.ScoreAddСoefficient,2)+1);
          
            //give reward and save;
        }
        UpdateUi();
    }

    private void UpdateUi()
    {
        if (currentAds == 0)
        {
            adsCountText.text = "Increase Score Сoefficient";
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
