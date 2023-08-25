using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayersHealManager : MonoBehaviour
{
  public Image playerHealBar;
   public Image enemyHealBar;
   [SerializeField] private FinishTrigers playerFinish;
   [SerializeField] private FinishTrigers enemyFinish;


   private bool isFinishGame;
   private void Update()
   {
       if (!isFinishGame)
       {
           if (playerHealBar.fillAmount <= 0)
           {
               isFinishGame = true;
               enemyFinish.FinishRace();
           }

           if (enemyHealBar.fillAmount <= 0)
           {
               isFinishGame = true;
               playerFinish.FinishRace();
           }
       }
       
   }
}
