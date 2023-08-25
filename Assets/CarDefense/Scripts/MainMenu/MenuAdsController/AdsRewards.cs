using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public abstract class AdsRewards : MonoBehaviour
{
   [SerializeField] protected Button adsButton;
   [SerializeField] protected TextMeshProUGUI adsCountText;
   [SerializeField] protected RewardVideoAds adsType;
   [SerializeField] protected int adsPrice;
   [SerializeField] protected int currentAds;
   [SerializeField] protected int currentCarId;

   
   public abstract void WatchAdsForReward();

   public abstract void GetReward();
   


}
