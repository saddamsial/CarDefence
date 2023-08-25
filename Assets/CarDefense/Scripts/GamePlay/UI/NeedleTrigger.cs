using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class NeedleTrigger : MonoBehaviour
{
   [SerializeField] private PlayerCarForce playerCarForce;
   [SerializeField] private RectTransform goodInterval;
   [SerializeField] private ScoreInfo scoreInfo;
   private WaitForSeconds wait6Second;
 

   private IEnumerator Start()
   {
       wait6Second = new WaitForSeconds(ES3.Load(SaveKeys.IapGoodIntervalDuration,0) +ES3.Load(SaveKeys.GoodIntervalDuration + GlobalCarsContainer.currentCar.CarId,6));
       StartCoroutine(ChangeGoodInterval());
       yield return new WaitForSeconds(1);
       playerCarForce.isIncrease = false; 
   }

   private void OnTriggerEnter(Collider other)
   {
         playerCarForce.isIncrease = true;
           scoreInfo.givePoint = true; 
       
    
   }

   private void OnTriggerExit(Collider other)
   {
       playerCarForce.isIncrease = false;
       scoreInfo.givePoint = false;
   }
   

   IEnumerator ChangeGoodInterval()
   {
      
       while (true)
       {
           //Change good interval position
           yield return wait6Second;
           goodInterval.localEulerAngles = new Vector3(goodInterval.eulerAngles.x ,goodInterval.eulerAngles.y, Random.Range(-90,70));
       }
      
   }
   
}
